﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Classes
{
    [DataContract]
    public class ConfirmJSON
    {
        [DataMember]
        public UserDTO user { get; set; }
        [DataMember]
        public int code { get; set; }
    }
}
