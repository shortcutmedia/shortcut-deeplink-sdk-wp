using System;
using System.Collections.Generic;
using System.Reflection;

namespace Shortcut.DeepLinking.Pcl
{
    public class SCEnvironment
    {
        public Dictionary<string, string> toMap()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add(KeyValues.PLATFORM_KEY, KeyValues.PLATFORM_VALUE);
            map.Add(KeyValues.PLATFORM_VERSION_KEY, Version);
            map.Add(KeyValues.PLATFORM_BUILD_KEY, Build);
            map.Add(KeyValues.MODEL_KEY, Model);
            return map;
        }

        public string toJson()
        {
            return "";
        }

        public string toString()
        {
            return "";
        }

        private string Version
        {
            get
            {
                var assembly = typeof(SCEnvironment).GetTypeInfo().Assembly;
                var assemblyName = new AssemblyName(assembly.FullName);
                return String.Format(@"{0}.{1}.{2}.{3}", assemblyName.Version.Major, assemblyName.Version.Minor, assemblyName.Version.Build, assemblyName.Version.Revision);
            }
        }

        private string Build
        {
            get
            {
                var assembly = typeof(SCEnvironment).GetTypeInfo().Assembly;
                var assemblyName = new AssemblyName(assembly.FullName);
                return assembly.GetHashCode().ToString();
            }
        }

        private string Model
        {
            get
            {
                var assembly = typeof(SCEnvironment).GetTypeInfo().Assembly;
                var assemblyName = new AssemblyName(assembly.FullName);
                return assemblyName.Name;
            }
        }

        //private string DeviceID
        //{
        //    get
        //    {
        //        HardwareToken token = HardwareIdentification.GetPackageSpecificToken(null);
        //        IBuffer hardwareId = token.Id;

        //        HashAlgorithmProvider hasher = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
        //        IBuffer hashed = hasher.HashData(hardwareId);

        //        string hashedString = CryptographicBuffer.EncodeToHexString(hashed);
        //        //string hashedString = Convert.ToBase64String(hashed);
        //        return hashedString;
        //    }
        //}
    }
}
