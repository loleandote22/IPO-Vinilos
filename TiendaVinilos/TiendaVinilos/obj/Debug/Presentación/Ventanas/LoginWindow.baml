   M S B A M L   `   `   `  ����H  DTiendaVinilos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TiendaVinilosTiendaVinilos  5   	       TiendaVinilos.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:TiendaVinilos     5   	     � Title$  login��5   	   $	��600��6   $
��1000��6$    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$ 20(�6)   �� 5       � ��
 �����6+   �� 5       � ��$ Medium"�6+   �� 5       � ��$ 0,40,0,0q�6'   5      �� 5   
   " ��6   5      5      .��5      ]� .+�5   
   �  � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6   ���#EEEEEE6(   �� 5      $-��'/Presentación/Imágenes/Sin nombre.png��6   $	��250��6C   $	��250��6P   $��0��6\   �� 5       $��1��6   ���#9e9e9e J� Opacity$	 0.9Q�67   � 5"      $��1��6    � RowDefinitions 5#      �� 5$      �� 5%      $
��auto �6$   �� 5&      .+�5)      �� $	��250��6   $��1��6)   $��1��66   	 �� Orientation$	 Vertical=�6F   .+�5+      �� 
���   �$��Iniciar Sesión��63   $��	Bodoni MT)�6I   $��40(�6`   $��Center=�6o   $
��Bold"�6�   �� 5.      $��Usuario��6    �� 5/      $��14(�6   $��Medium"�6-   $��	Bodoni MT)�6A   
 �� 
CaretBrush

 �����
���   �$��0,0,0,3q�50   2   $��27��6L   $��Center=�6X   $��0,5,0,0q�6z   $��20,0,0,0q�6�    �� 	MaxLength$ 25��51      ��5/   p   �� *Nombre+ �� UpdateSourceTrigger$ 	LostFocus=�.��51   -   ��52      �� 53       �� ImageSource$, &/Presentación/Imágenes/user-icon.png��6)    j� Stretch$
 None=�6\    j� 
AlignmentX$
 Left=�6k   .��54   .   55      �� 58      $��Contraseña��6    G� 59      -   5        $��
contaseña��59   "   $��14(�63   $��Medium"�6B   $��	Bodoni MT)�6V    G� 
CaretBrush
 �����
���   �$��0,0,0,3q�5:   2   $��27��6L   $��Center=�6X   $��0,5,0,0q�6z   $��20,0,0,0q�6�   ��5;      �� 5<      $+ %/Presentación/Imágenes/key-icon.png��6)   $
 None=�6[   $
 Left=�6j   5>      �� 5A      -   5         ��Name$ btnLogin��5A      $��0q�60   $��Entrar��6D   
�������$��20(�6h   $��	Bodoni MT)�6v    � Cursor$
 Hand��6�   $��0,50,0,0q�5B      ��6/   �� *AccederCommand+��5C      �� 5D      " ��6$   .�5E   "   ��  � ��
 �   �6?    �� Triggers 5F   "   P� 5G   &    P� Property �@J�IsMouseOver P� Value . . �5H   *   ��  � ��
 �����6G   5I   '   5K      ��5M      �� 5N       �� 
TargetType" ��6.   .R�5O   "   �� $	��150��6)   $��40��65    �� CornerRadius$ 20��5P   )   #��z��5Q   )   ._�5R   &   �� $��Center=�67   $��Center=�5S   7   5T   #   5U      5W      5X      5Y      5Z      5[      5\      