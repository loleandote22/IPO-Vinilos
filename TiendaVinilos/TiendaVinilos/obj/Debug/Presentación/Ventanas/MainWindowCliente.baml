   M S B A M L   `   `   `  ����H  DTiendaVinilos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TiendaVinilosTiendaVinilos  5   	   %    TiendaVinilos.MainWindowCliente   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:TiendaVinilos     5   	   $	��450��5   G   $
��1000��6T     � Title  6	   �� *Titulo+ �� UpdateSourceTrigger$ PropertyChanged=� � DataContext 5	      (  "TiendaVinilos.ViewModelMainCliente  5
   
    � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value��%  '��       '_� �     '��      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 30��6'    5      P� 5       �@J�IsMouseOver	 . . �5      ��  � ��
 ����63   5      5      �� 5   
   " _�6   .�5      ��  � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 30��6'   �� 5       � ��
 ���� 6+   �� 5       � ��$ 0q�6(   �� 5       � ��$ 0q�60   �� 5       � ��$ Stretch=�6;   5!      5"      .��5#      ]� .+�5$   
   � $	��Top=�6   
 � RowDefinitions
 5%      �� 5&      $
��auto �6    �� 5'      .+�5)      � ���#5E5E5E$	�� 60��6(    � ColumnDefinitions 5*      �� 5,      �� 5.      $
��auto �6'   �� 50      $
��auto �6'   �� 52      $
��auto �6'   .+�54      �� $�� auto��6   $��30(�6(   ���#eeeeee$��Center=�6L   $��lucky skirt)�6n   $
��30,0q�6�   ��6�   �� *InicioCommand+��55      �� 56      ���#5E5E5E$	�� 70��66   ._�57      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6B   .+�58   "   �� $'��!/Presentación/Imágenes/Logo.png��6(   $��	20,5,0,10q�6Q   $��50��6d   �� 59   "   $��lucky skirt)�6,   $��Center=�6E   ���#EEEEEE$��
VINILOS.SA��6u   5:      5;      5=      �� 5>      $	��150��6   
�������$��1��6�   $��Center=�6�   $
��30,0q�6�   ��6'   �� *ListaIdiomas+ �� SelectedItem 6_   �� *IdiomaSeleccionado+$ PropertyChanged=�6�   �� 5?      $��2��6   $��Center=�6)   ��6D   �� *CommandCompra+.��5@      �� $ 
Horizontal=�6!   ���#5E5E5E$��Center=�6O   $
��auto��6j   .+�5A      �� ���#5E5E5E$��2��6   
���������6    �� *ElementosCarrito+$ PropertyChanged=�6�   �� 5B      $F��@/Presentación/IconosCliente/bolso-shopping-cuadrado-con-asa.png��6    5C      5D      �� 5E      $��3��6   $��	20,0,30,0q�6L   $��-1q�6_   ��6)   �� *UsuarioCommand+.��5F      � ���#5E5E5E.+�5G      �� $.��(/Presentación/IconosCliente/usuario.png��6    5H      5I      5J      � 5K      $��1��6   ���#2C2C2C$	��Top=�65   $��40��6M    5L      �� 5M      $	��240��6'   �� 5N      $	��240��6'   �� 5O      $	��240��6'   �� 5P      $	��240��6'   .+�5S      �� $
��10,0q�6=   ��6   �� *CommandArtistas+��5T      �� 5U      ���#2C2C2C$��-1q�66   ._�5V      � $��Center=�6#    5W   "   �� 5X   &   �� 5Y   &   .+�5[   "   �� $2��,/Presentación/IconosCliente/guitarrista.png��6(   �� 5\   "   $��1��6(   $��Artistas��68   $��16(�6L   5]      5^      5`      �� 5a      $��1��6   $��16(�6K   $
��10,0q�6Y   ��6)   �� *CommandDiscos+��5b      �� 5c      ���#2C2C2C$��-1q�66   ._�5d      � $��Center=�6#    5e   "   �� 5f   &   �� 5g   &   .+�5i   "   �� $-��'/Presentación/IconosCliente/vinilo.png��6(   �� 5j   "   $��1��6(   $��Discos��68   5k      5l      5n      �� 5o      $��2��6   
������ $
��10,0q�6i   $��16(�6w   ��6B   �� *CommandPromociones+��5p      �� 5q      ���#2C2C2C$��-1q�66   ._�5r      � $��Center=�6#    5s   "   �� 5t   &   �� 5u   &   .+�5w   "   �� $1��+/Presentación/IconosCliente/gran-venta.png��6(   $��Right=�6\   �� 5x   "   $��1��6(   $��Promociones��68   5y      5z      5|      �� 5}      $��3��6   $��16(�6N   $
��10,0q�6\   ��6*   �� *CommandContacto+��5~      �� 5      ���#2C2C2C$��-1q�66   ._�5�      � $��Center=�6#    5�   "   �� 5�   &   �� 5�   &   .+�5�   "   �� $0��*/Presentación/IconosCliente/comunicar.png��6(   �� 5�   "   $��1��6(   $��Contacto��68   5�      5�      5�      5�      5�       � 5�   
     � NavigationUIVisibility$ Hidden=�6R   ��6   �� *
Pantalla+$ PropertyChanged=�6R   5�      5�      