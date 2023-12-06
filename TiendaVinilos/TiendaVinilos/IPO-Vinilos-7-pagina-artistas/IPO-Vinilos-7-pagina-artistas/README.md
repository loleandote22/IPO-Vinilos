# IPO-Vinilos
## Estructura del proyecto
El proyecto se dividira en tres carpetas principales entendiendo las capas de diseño:
### Modelo 
Contendra el objeto Modelo (entidades y el contexto de la base de datos)
### Vista
Contendra las interfaces de usuario separados en 
#### Ventanas
Esta carpeta contendrá las ventanas principales del programa (login y ventana principal tanto de cliente como de administrador)
#### Páginas
En esta carpeta estaran las paginas a las que se accede desde la ventana
#### Recursos
En esta carpeta estaran las imagenes e iconos separados en sus respectivas carpetas
### ViewModel
Contendra los controladores de las interfaces de usuario
## Controladores de las interfaces de usuario
Los controladores de las interfaces son clases con el formato "DataContextNombreDeVentana". Aquí se crean las funcionalidades de los botones y se conectan con la base de datos. los datos guardan como atributos privados y se generan las propiedades (pulsar boton derecho sobre el atributo)

## Entidades
Las entidades se generan con mediante el EntityAdo creando la conexión con la báse de datos correspondiente