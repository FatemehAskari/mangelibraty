   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.return22   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   -   5          � Title$  return22��5   	   $	��300��6   $	��430��6'    � WindowStyle$
 None=�63    � WindowStartupLocation$ CenterScreen=�5	   	   ���#bf00ff � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency . .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $
��2.1* �6    �� 5      $
��2.5* �6    .+�5      ��  �� CornerRadius$ 5��6   $��2��6&   ��5      �� 5      .��5      �  � Color$ #B879D4��6'    � Offset$	 0.0Q�67   6F   � 5      $ #5256B7��6'   $ 1Q�67   6D   5      5      �� 5      $��0��6   .+�5      �� -   5        $
��btn1��5      $��40��5!      $��40��6    $��Right=�5"      $	��Top=�5#      $��	200,0,0,0q�5$      ��5%      �� 5&      -   5        	close��	 �� ImageSource$	 	Close.png��5&   4   .��5(      �� $��	close.png��6   $��40��5)      $��40��5*      
 J� IsManipulationEnabled
 . 6!   5+      5,      �� 5.      $��0��6   $��Center=�6&   $��0q�6A   .+�5/      �� -   5         ��Name$ image��5/      $��
images.png��6'   $��80��50      $��0,-100,0,-200q�6%   �� 51      -   5         ��Name$ title1��51      $��
Returnbook��6,   $��	helvetica)�52      $��30(�61   
�������$��Center=�53   -   $��0,100,0,-10q�6J   54      �� 56      $��1��6   $��Center=�6'   $��0q�6C   .+�57      �� -   5        $
 name��57      $
��Name��6*   $��	helvetica)�58      $��15(�61   
�������$
��Left=�59   -   $��15,30,0,150q�6H   5;      �� 5=      $��1��6   $��Center=�6'   $��0q�6C   .+�5>      �� -   5         ��Name$ namebook��5>      $��15,-5,40,60q�6,   5?      �� 5B      $��1��6   $��Center=�6'   $��0q�6C   .+�5C      �� -   5         ��Name$ return��5C      $��RETURN��6)   $��20,100,20,10q�6:   $��40��6P   $	��300��6\   
���������5D      �� 5E      $	 
button.png��6%   5G      5H      5K      5M      5N      