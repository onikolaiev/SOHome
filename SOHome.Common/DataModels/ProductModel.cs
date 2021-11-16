using SOHome.Common.Models;

using System;
using System.ComponentModel.DataAnnotations;

namespace SOHome.Common.DataModels
{
    public class ProductModel : ObservableObject
    {
        #region Váriaveis privadas
        private int code;
        private string barcode;
        private string name;
        private decimal price;
        #endregion
        #region Propriedades
        /// <summary>
        /// Código do produto
        /// </summary>
        [Display(Name = "Código")]
        public int Code { get => code; set => SetProperty(ref code, value); }
        /// <summary>
        /// Código de barras do produto
        /// </summary>
        [Display(Name = "Código de barras")]
        public string Barcode { get => barcode; set => SetProperty(ref barcode, value); }
        /// <summary>
        /// Nome do produto
        /// </summary>
        [Display(Name = "Nome")]
        public string Name { get => name; set => SetProperty(ref name, value); }
        /// <summary>
        /// Preço médio de custo
        /// </summary>
        [Display(Name = "Preço")]
        public decimal Price { get => price; set => SetProperty(ref price, value); }
        /// <summary>
        /// Data da ultima vez que o produto foi comprado
        /// </summary>
        [Display(Name = "Ultima compra")]
        public DateTime? LastPurchase { get; set; }
        #endregion
    }
}
