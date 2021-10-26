using PavilionKyrpton.Entities;
using PavilionKyrpton.ExcelLoaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionKyrpton.ApplicationMethods
{
    public static class LoadFileMethods
    {
        public static FileClass loadFile(string loader)
        {
            var File = new FileClass();

            switch (loader)
            {

                case "enagasload":
                    EnagasExcelLoader eLoader = new EnagasExcelLoader();
                    return eLoader.loadEnagasFile();
                case "prismaauction":
                    PrismaAuctionLoader ePrismaLoader = new PrismaAuctionLoader();
                    return ePrismaLoader.LoadPrismaActionFile();

            }

            return File;

        }

    }
}
