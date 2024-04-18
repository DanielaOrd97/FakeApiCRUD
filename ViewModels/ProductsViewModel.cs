using CommunityToolkit.Mvvm.Input;
using FakeAppApi.Dtos;
using FakeAppApi.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FakeAppApi.ViewModels
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private FakeApiService api = new();
        public ProductData Producto { get; set; } = new();
        public CategoryDto Categoria {  get; set; } = new();    
        public ProductDataPostDto ProductoPost { get; set; } = new();
        public ProductDataPutDto ProductoPut { get; set; } = new();
        public List<ProductData> ListaProductos { get; set; }
        public List<CategoryDto> ListaCategorias { get; set; }
        private string imageUrls;
        public string ImageUrls
        {
            get { return imageUrls; }
            set
            {
                if (imageUrls != value)
                {
                    imageUrls = value;
                    OnPropertyChanged(nameof(ImageUrls));
                }
            }
        }
        public ICommand AgregarProductosCommand { get; set; }
        public ICommand VerIdProductoCommand { get; set; } 
        public ICommand EditarProductosCommand { get; set; }
        public ICommand EliminarProductosCommand { get; set; }

        public static int idProducto;

        public ProductsViewModel()
        {
            api = new();
            //AgregarProductosCommand = new RelayCommand(AgregarProductos);
            AgregarProductosCommand = new AsyncCommand(AgregarProductos);
            VerIdProductoCommand = new RelayCommand<int>(VerIdProducto);
            //EditarProductosCommand = new RelayCommand(EditarProductos);
            EditarProductosCommand = new AsyncCommand(EditarProductos);
            EliminarProductosCommand = new AsyncCommand<int>(EliminarProductos);
            MostrarProductos();
            MostrarCategorias();
        }

        public async Task MostrarProductos()
        {
            //api = new();
            ListaProductos = await api.GetProducts();

            OnPropertyChanged(nameof(ListaProductos));

        }

        public async Task MostrarCategorias()
        {
            ListaCategorias = await api.GetAllCategories();

            OnPropertyChanged(nameof(ListaCategorias));
        }

        public async Task  AgregarProductos()
        {
            if (ProductoPost != null && Categoria!=null)
            {
                ProductoPost.categoryId = Categoria.id;


               var p = imageUrls;
               await api.CreateProducts(ProductoPost,p);
                OnPropertyChanged(nameof(ListaProductos));
                MostrarProductos();
            }
        }


        public void VerIdProducto(int id)
        {
            if (id > 0)
            {
                idProducto = id;
            }
        }


        public async Task EditarProductos()
        {
            if(ProductoPut != null)
            {
               await api.UpdateProducts(ProductoPut, idProducto);
                MostrarProductos();
            }
        }

        public async Task EliminarProductos(int id)
        {
            if(id > 0)
            {
                await api.DeleteProducts(id);
                MostrarProductos();
            }
            
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
