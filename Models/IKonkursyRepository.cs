﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public interface IKonkursyRepository
    {
        IEnumerable<Konkursy> Konkursys { get; }
        void SaveKonkursy (Konkursy konkursy);
    }
}