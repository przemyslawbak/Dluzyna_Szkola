﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IZajeciaDodatkoweRepository
    {
        IEnumerable<ZajeciaDodatkowe> ZajeciaDodatkowes { get; }
        void SaveZajecia(ZajeciaDodatkowe zajecia);
    }
}