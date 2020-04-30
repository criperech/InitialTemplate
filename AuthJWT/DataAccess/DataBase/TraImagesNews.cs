using System;
using System.Collections.Generic;

namespace WebApi.DataAccess.DataBase
{
    public partial class TraImagesNews
    {
        public string ImnIdImagePk { get; set; }
        public string ImnName { get; set; }
        public string ImnNameFile { get; set; }
        public int ImnIdTypeFk { get; set; }
        public bool ImnState { get; set; }
    }
}
