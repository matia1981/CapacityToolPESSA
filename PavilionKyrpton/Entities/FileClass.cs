using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionKyrpton.Entities
{
    public class FileClass
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string FileType { get; set; }

        public DateTime LoadTime { get; set; }

        public string LoadResult { get; set; }

        public int Records { get; set; }

        public List<EnagasFile> EnagasFiles { get; set; }

        public List<PrismaAuctionFile> PrismaAuctionContracts { get; set; }
    }
}
