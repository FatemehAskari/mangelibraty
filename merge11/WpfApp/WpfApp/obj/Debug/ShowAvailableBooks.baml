   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.ShowAvailableBooks   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   -   5          � Title$  ShowAvailableBooks��5   	   $	��700��6$   $	��900��61    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         btnClose �� 
TargetType �� Property �� Value��%z   &	        �� 5   
   " ��6!   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 ���� 6,   5      5      .��5      � .+�5   
   ��  �� CornerRadius$ 10��6   $��2��6#   $��2��64   ��5      �� 5      .��5      � 	 � Color$	 #B879D4��6#   
 � Offset$	
 0.0Q�63   6B   � 5      $	 #5256B7��6#   $
 1Q�63   6@   5      5      �� 5"   
   .��5#      �� ��6   �� *AvailableBooks+��5$      �� 5%      .R�5&      �  � ColumnDefinitions 5'      �� 5(   "   �� 5)   "    � RowDefinitions 5+      �� 5,   "   62   �� 5-   "   62   .+�50      �� $��0��6(   $
��Name��68   $��20,40,20,20q�51   ,   $��	Helvetica)�6A   $��18(�52   ,   ���	#FFFBFBFB$��0��53   ,   $
��Bold"�69   �� 54      $��0��6(   $��20,20q�68   $��	Helvetica)�56   ,   $��18(�6C   ���	#FFFBFBFB$��1��58   ,   ��55   ,   �� *name+58   ,   �� 59      $��1��6(   $��Writer��68   $��20,40,20,20q�5:   ,   $��	Helvetica)�6A   $��18(�5;   ,   ���	#FFFBFBFB$��0��5<   ,   $
��Bold"�69   �� 5=      $��1��6(   $��20,20q�68   $��	Helvetica)�5?   ,   $��18(�6C   ���	#FFFBFBFB$��1��5A   ,   ��5>   ,   �� *writer+5A   ,   5B      5C      5E      5F      �� 5I   
   -   5        $	��btn��5I      #��[  5J      $��40��5K      $��40��6    $	��Top=�5L      $��0,0,15,0q�5M      $��Right=�6'   $��1��5N      .��5O      �� $��	close.png��6   $��40��5P      $��40��5Q       J� IsManipulationEnabled . $��Right=�5R      $	��Top=�61   5S      5T      5U      