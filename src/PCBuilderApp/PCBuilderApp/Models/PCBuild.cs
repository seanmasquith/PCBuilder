using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilderApp.Models
{
    //The PCBuild class maps to the PCBuild table in the SQLite database.
    [Table("PCBuild")]
    public class PCBuild
    {
        //The ID is the primary key.
        [NotNull, PrimaryKey, AutoIncrement, Unique, Column("PCBuildID")]
        public int PCBuildID { get; set; }
        [NotNull]
        public string PCBuildName { get; set; }
        public string PCCpu { get; set; }
        public string PCCpuCooler { get; set; }
        public string PCGpu { get; set; }
        public string PCMotherboard { get; set; }
        public string PCRam { get; set; }
        public string PCStorage { get; set; }
        public string PCPsu { get; set; }
        public string PCCase { get; set; }
    }
}