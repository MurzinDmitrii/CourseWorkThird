//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Курсач.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CardTablePart
    {
        public string DesiaseId { get; set; }
        public int ID { get; set; }
        public int WorkerId { get; set; }
    
        public virtual Card Card { get; set; }
        public virtual Desiase Desiase { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
