using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pinch.SDK.Helpers
{
    public class FileDto
    {
        public Stream Stream { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }
    }
}