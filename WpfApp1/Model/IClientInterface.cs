﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public interface IClientInterface
    {
        public List<ClientModel> GetAllClients();
    }
}