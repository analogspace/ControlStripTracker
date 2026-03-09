using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessControl
{
    internal class Reading(int controlNumber, DateTime dateTime, PatchValue dMinpatch, PatchValue ldPatch, PatchValue hdPatch, PatchValue dMaxPatch, PatchValue yellowPatch)
    {
        public int ControlNumber { get; set; } = controlNumber;
        public DateTime DateTime { get; set; } = dateTime;
        public PatchValue DMinPatch { get; set; } = dMinpatch;
        public PatchValue DMaxPatch { get; set; } = dMaxPatch;
        public PatchValue YellowPatch { get; set; } = yellowPatch;
        public PatchValue LDPatch { get; set; } = ldPatch;
        public PatchValue HDPatch { get; set; } = hdPatch;

    }
    public enum PatchName {Dmin, LD, HD, Dmax, Yellow}
}
