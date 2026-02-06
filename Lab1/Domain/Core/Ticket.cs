using Lab1.Domain.Core.Interfaces;
using Lab1.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Core
{
    class Ticket : SellableItemBase, IIdenifiable
    {
        public string Id { get; }
    }
}
