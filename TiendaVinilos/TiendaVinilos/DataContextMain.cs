﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Input;

namespace TiendaVinilos
{
    internal class DataContextMain: ViewModelBase
    {
        private String texto;
        private String idiomaSeleccionado;
        private ICommand commandArtistas;
        private ICommand commandDiscos;
        private ICommand commandPromociones;
        private ICommand commandContacto;
        private ICommand commandCompra;
        private ICommand usuarioCommand;
        private ICommand inicioCommand;
        private List<String> listaIdiomas = new List<string> { "Español", "Inglés" };
        private int elementosCarrito;
        private Page pantalla;
        private String titulo;
       // private 
        public DataContextMain()
        {
            commandArtistas= new RelayCommand(new Action<object>((o) => verArtistas()));
            commandDiscos= new RelayCommand(new Action<object>((o) => verDiscos()));
            commandPromociones = new RelayCommand(new Action<object>((o) => verPromociones()));
            commandContacto =new RelayCommand(new Action<object>((o) => verContacto()));
            commandCompra = new RelayCommand(new Action<object>((o) => verCompra()));
            usuarioCommand= new RelayCommand(new Action<object>((o) => verPerfil()));
            inicioCommand = new RelayCommand(new Action<object>((o) => verInicio()));
            elementosCarrito = 0;
            IdiomaSeleccionado = listaIdiomas[0];
            Titulo = "Bienvenido";
            DateTime fecha = System.DateTime.Now;
        }

        public string Texto { get => texto;
            set
            {
                texto = value;
                OnPropertyChanged("Texto");
            }

        }

        public string IdiomaSeleccionado { get => idiomaSeleccionado; set => idiomaSeleccionado = value; }
        public List<string> ListaIdiomas { get => listaIdiomas; set => listaIdiomas = value; }
        public ICommand CommandArtistas { get => commandArtistas; set => commandArtistas = value; }
        public ICommand CommandDiscos { get => commandDiscos; set => commandDiscos = value; }
        public ICommand CommandPromociones { get => commandPromociones; set => commandPromociones = value; }
        public ICommand CommandContacto { get => commandContacto; set => commandContacto = value; }
        public ICommand CommandCompra { get => commandCompra; set => commandCompra = value; }
        public ICommand UsuarioCommand { get => usuarioCommand; set => usuarioCommand = value; }
        public ICommand InicioCommand { get => inicioCommand; set => inicioCommand = value; }
        public int ElementosCarrito { get => elementosCarrito; set { elementosCarrito = value;OnPropertyChanged("ElementosCarrito"); } }
        public String Titulo { get => titulo;set=>titulo = value; }
        public Page Pantalla { get => pantalla; set {
                pantalla = value;
                OnPropertyChanged("Pantalla");
            } }


        // public DateTime Fecha { get=> }
        private void verArtistas() { MessageBox.Show("Artistas"); }
        private void verDiscos() { MessageBox.Show("Discos"); }
        private void verPromociones() { MessageBox.Show("Promociones"); }
        private void verContacto() { MessageBox.Show("Contacto"); }
        private void verCompra() { MessageBox.Show("Compra"); }
        private void verPerfil() { /*MessageBox.Show("Perfil"); */ElementosCarrito += 1; }
        private void verInicio() { MessageBox.Show("Inicio"); }
    }
}
