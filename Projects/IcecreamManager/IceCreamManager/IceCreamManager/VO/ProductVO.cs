﻿using IceCreamManager.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamManager.VO
{
    public class ProductVO 
    {

        public int pro_No { get; set; }
        public string pro_Name { get; set; }
        public byte[] pro_Img { get; set; }
        public int mat_No { get; set; }
        public int pro_Price { get; set; }

    }
}
