﻿using System;

namespace EscrowPro.Core.Dtos
{
    public class ReadProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
    }
}
