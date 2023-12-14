﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Input;
using TiendaVinilos.Paginas;


namespace TiendaVinilos
{
    internal class ViewModelAdministrador : ViewModelBase
    {

        private ICommand commandArtistas;
        private ICommand commandDiscos;
        private ICommand commandPromociones;
        private ICommand commandContacto;
        private object pantalla;
        private String titulo;
        public TiendaVinilosEntities contexto = new TiendaVinilosEntities();

        public ViewModelAdministrador()
        {
            commandArtistas = new RelayCommand(new Action<object>((o) => verArtistas()));
            commandDiscos = new RelayCommand(new Action<object>((o) => verDiscos()));
            commandPromociones = new RelayCommand(new Action<object>((o) => verPromociones()));
            commandContacto = new RelayCommand(new Action<object>((o) => verContacto()));
        }
        public ICommand CommandArtistas { get => commandArtistas; set => commandArtistas = value; }
        public ICommand CommandDiscos { get => commandDiscos; set => commandDiscos = value; }
        public ICommand CommandPromociones { get => commandPromociones; set => commandPromociones = value; }
        public ICommand CommandContacto { get => commandContacto; set => commandContacto = value; }
        public String Titulo { get => titulo; set { titulo = value; ; OnPropertyChanged("Titulo"); } }

        public object Pantalla { 
            get => pantalla; 
            set { pantalla = value; OnPropertyChanged("Pantalla"); }  
        }

        private void verArtistas()
        {
            Artistas artistas = new Artistas();
            artistas.DataContext = new ViewModel.ViewModelArtistas(artistas, contexto);
            Pantalla = artistas;
            Titulo = "Atistas";
        }
        private void verDiscos() { MessageBox.Show("Discos"); }
        private void verPromociones() { MessageBox.Show("Promociones"); }
        private void verContacto()
        {
            MessageBox.Show("Contacto");
        }
    }
}