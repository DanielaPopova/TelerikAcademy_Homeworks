namespace Kitchen.Models.Products
{
    using Contracts;
    
    public abstract class Vegetable : IVegetable
    { 
        public Vegetable()
        {
            this.IsCut = false;
            this.IsPeeled = false;           
        }       

        public bool IsCut { get; set; }        

        public bool IsPeeled { get; set; }     
    }
}
