using System.IO.Compression;
using Mammoth.Couscous.java.io;
using Mammoth.Couscous.java.util;
using Ionic.Zip;

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.archives {
    internal class ZippedArchive : Archive {
        private readonly ZipFile _zipFile;
        
        internal ZippedArchive(File file) {
            _zipFile = ZipFile.Read(file.Path);
        }

        internal ZippedArchive(System.IO.Stream stream) {
            _zipFile = ZipFile.Read(stream);
        }
        
        public Optional<InputStream> tryGetInputStream(string name) {
            var entry = _zipFile[name];
            if (entry == null) {
                return Optional.empty<InputStream>();
            } else {
                return Optional.of(ToJava.StreamToInputStream(entry.OpenReader()));
            }
        }
        
        public void close() {
            _zipFile.Dispose();
        }
    }
}
