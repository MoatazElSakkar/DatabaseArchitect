using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

using System.Threading.Tasks;

namespace DBA.Bookkeeper
{
    public enum AccessLevel
    {
        System,             //Database Architect centeral account with highest privilage on all databases
        Administrator,      //May modify database settings/structure or data
        DatabaseOperator,   //May modify database structure or data
        DataEntry,          //May modify database data
        Dataviewer          //May view database data
    }

    public class CredentialCertificate
    {
        Exception FileTamperingException = new Exception("Security Alert: Certificate file has been improperly tampered with");
        Exception FileCorruptException = new Exception("File damaged or corrupt");

        public byte[] UseHash; //20 bytes
        public byte[] credHash; //20bytes
        public AccessLevel CertificateLevel;//1 byte
        public byte[] CertificateHash; //20 bytes

        public static CredentialCertificate CreateCertificate(string Username, string Password, AccessLevel Access)
        {
            byte[] shaUsername = Username.ComputeSha1HashBytes();
            byte[] shaPassword = Password.ComputeSha1HashBytes();
            return new CredentialCertificate()
            {
                UseHash = shaUsername,
                credHash = shaPassword,
                CertificateLevel = Access,
                CertificateHash = (Encoding.Default.GetString(shaUsername) + Encoding.Default.GetString(shaPassword) + Access).ComputeSha1HashBytes()
            };
        }

        public CredentialCertificate ReadCertificate(string FileName)
        {
            FileStream CertFile = new FileStream(DBA.Definitions.Fields.CertificatesLoc+FileName, FileMode.Open);
            byte[] UsernameSha = new byte[20];
            byte[] PasswordSha = new byte[20];
            byte[] AccessLevel = new byte[1];
            byte[] CertificateHash = new byte[20];
            try {
                CertFile.Read(UsernameSha, 0, 20);
                CertFile.Read(PasswordSha, 20, 20);
                CertFile.Read(AccessLevel, 40, 1);
                CertFile.Read(CertificateHash, 41, 20);
            }
            catch {
                throw FileCorruptException;
            }
            
            if ((Encoding.Default.GetString(UsernameSha) + Encoding.Default.GetString(PasswordSha) + AccessLevel).ComputeSha1HashBytes() != CertificateHash)
                throw FileTamperingException;

            CredentialCertificate ReadCertificate = new CredentialCertificate()
            {
                UseHash = UsernameSha,
                credHash = PasswordSha,
                CertificateLevel = (AccessLevel)AccessLevel[0],
                CertificateHash = CertificateHash
            };
            return ReadCertificate;
        }

        public void WriteCertificate()
        {
            FileStream CertFile = new FileStream(DBA.Definitions.Fields.CertificatesLoc + Encoding.Default.GetString(UseHash,0,20)+".dbcf", FileMode.OpenOrCreate);
            CertFile.Write(UseHash,0,20);
            CertFile.Write(credHash, 0, 20);
            CertFile.WriteByte((byte)CertificateLevel);
            CertFile.Write((Encoding.Default.GetString(UseHash) + Encoding.Default.GetString(credHash) + CertificateLevel).ComputeSha1HashBytes(), 0, 20);
            CertFile.Close();
        }
    }
}
