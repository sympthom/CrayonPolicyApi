using System;
using System.Collections.Generic;
using System.Text;

namespace Crayon.Api.Policy
{
    public sealed class Policy
    {
        public int Id { get; set; }

        public string InsuranceNr { get; set; }

        public bool IsComplete { get; set; }
    }
}
