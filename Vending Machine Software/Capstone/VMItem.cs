namespace Capstone
{
    using System;

    /// <summary>
    /// Represents a Vending Machine Item
    /// </summary>
    public class VMItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VMItem"/> class
        /// </summary>
        /// <param name="slotLocation">Location in the machine</param>
        /// <param name="productName">product name</param>
        /// <param name="price">price</param>
        /// <param name="type">type</param>
        public VMItem(string slotLocation, string productName, decimal price, string type)
        {
            this.SlotLocation = slotLocation;
            this.ProductName = productName;
            this.Price = price;
            this.Type = type;
            this.Quantity = 5;
        }

        /// <summary>
        /// Gets the location of a vending machine item, also serves as the dictionary key
        /// </summary>
        public string SlotLocation { get; }

        /// <summary>
        /// Gets the name of the product
        /// </summary>
        public string ProductName { get; }

        /// <summary>
        /// Gets the price of the product
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// Gets the "type" of the product
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets or sets the quantity in the machine
        /// </summary>
        public int Quantity { get; set; }
    }
}
