//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAMStock.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ComponentsOfPedals
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public int Amount { get; set; }
        public int PedalId { get; set; }
    
        public virtual Component Component { get; set; }
        public virtual Pedal Pedal { get; set; }
    }
}
