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
    
    public partial class Requsites
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int BankId { get; set; }
    
        public virtual Bank Bank { get; set; }
    }
}
