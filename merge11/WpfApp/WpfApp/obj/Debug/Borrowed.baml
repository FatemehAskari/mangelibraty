   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.Borrowed   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   -   5          � 
ResizeMode$  NoResize=�5       � Title$ Borrowed��5   	   $	��700��6   $	��900��6'    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         btnClose �� 
TargetType �� Property �� Value��%z   &	        �� 5   
   " ��6!   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 ���� 6,   5      5      .��5      � .+�5   
   ��  �� CornerRadius$ 10��6   $��2��6#   $��2��64   ��5      �� 5      .��5      � 	 � Color$	 #B879D4��6#   
 � Offset$	
 0.0Q�63   6B   � 5      $	 #5256B7��6#   $
 1Q�63   6@   5      5      �� 5    
   .��5!      �� ��6   �� *BorrowedItems+��5"      �� 5#      .R�5$      �  � ColumnDefinitions 5%      �� 5&   "   �� 5'   "   �� 5(   "    � RowDefinitions 5*      �� 5+   "   62   �� 5,   "   62   .+�5/      �� $��0��6(   $��20,20q�68   $��Email��50   ,   $��	Helvetica)�51   ,   $��18(�6C   ���	#FFFBFBFB$��0��53   ,   $
��Bold"�69   �� 54      $��1��6(   $��20,20q�68   $��	Book Name��55   ,   $��	Helvetica)�56   ,   $��18(�6C   ���	#FFFBFBFB$��0��58   ,   $
��Bold"�69   �� 59      $��2��6(   $��20,20q�68   $��Borrowed Date��5:   ,   $��	Helvetica)�5;   ,   $��18(�6C   ���	#FFFBFBFB$��0��5=   ,   $
��Bold"�69   �� 5@      $��0��6(   $��20,20q�68   $��	Helvetica)�5B   ,   $��18(�6C   ���	#FFFBFBFB$��1��5D   ,   ��5A   ,   �� *email+5D   ,   �� 5E      $��1��6(   $��20,20q�68   $��	Helvetica)�5G   ,   $��18(�6C   ���	#FFFBFBFB$��1��5I   (   ��5F   ,   �� *
bookName+5I   (   �� 5J      $��2��6(   $��20,20q�68   $��	Helvetica)�5L   ,   $��18(�6C   ���	#FFFBFBFB$��1��5N   (   ��5K   ,   �� *date+5N   (   5O      5P      5R      5S      �� 5V   
   -   5        $	��btn��5V      #��[  5W      $��40��5X      $��40��6    $	��Top=�5Y      $��0,0,20,0q�5Z      $��Right=�6'   $��1��5[      .��5\      �� $��	close.png��6   $��40��5]      $��40��5^       J� IsManipulationEnabled . $��Right=�5_      $	��Top=�61   5`      5a      5b      