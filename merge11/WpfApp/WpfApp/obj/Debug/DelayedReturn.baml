   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.DelayedReturn   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   -   5          � WindowStyle$
  None=�5   	    � Title$ DelayedReturn��5	   	   $	��700��6   $	��900��6,    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         btnClose �� 
TargetType �� Property �� Value��%z   &	        �� 5   
   " ��6!   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 ���� 6,   5      5      .��5      � .+�5   
   ��  �� CornerRadius$ 10��6   $��2��6#   $��2��64   ��5      �� 5      .��5      � 	 � Color$	 #B879D4��6#   
 � Offset$	
 0.0Q�63   6B   � 5      $	 #5256B7��6#   $
 1Q�63   6@   5      5      �� 5"   
   .��5#      �� ��6   �� *
delayedMem+��5$      �� 5%      .R�5&      �  � ColumnDefinitions 5'      �� 5(   "   �� 5)   "   �� 5*   "    � RowDefinitions 5,      �� 5-   "   62   �� 5.   "   62   .+�51      �� $��0��6(   $��	Book Name��68   $��20,40,20,20q�52   ,   $��	Helvetica)�6A   $��18(�53   ,   ���	#FFFBFBFB$��0��54   ,   $
��Bold"�69   �� 55      $��1��6(   $��Member Email��68   $��20,40,20,20q�56   ,   $��	Helvetica)�6A   $��18(�57   ,   ���	#FFFBFBFB$��0��58   ,   $
��Bold"�69   �� 59      $��2��6(   $��Days Delayed��68   $��20,40,20,20q�5:   ,   $��	Helvetica)�6A   $��18(�5;   ,   ���	#FFFBFBFB$��0��5<   ,   $
��Bold"�69   �� 5>      $��0��6(   $��20,20q�68   $��	Helvetica)�5@   ,   $��18(�6C   ���	#FFFBFBFB$��1��5B   ,   ��5?   ,   �� *	_bookName+5B   ,   �� 5C      $��1��6(   $��20,20q�68   $��	Helvetica)�5E   ,   $��18(�6C   ���	#FFFBFBFB$��1��5G   ,   ��5D   ,   �� *_email+5G   ,   �� 5H      $��2��6(   $��20,20q�68   $��	Helvetica)�5J   ,   $��18(�6C   ���	#FFFBFBFB$��1��5L   ,   ��5I   ,   �� *_delayedDays+5L   ,   5M      5N      5P      5Q      �� 5T   
   -   5        $	��btn��5T      #��[  5U      $��40��5V      $��40��6    $	��Top=�5W      $��
200,0,15,0q�5X      $��Right=�6)   $��1��5Y      .��5Z      �� $��	close.png��6   $��40��5[      $��40��5\       J� IsManipulationEnabled . $��Right=�5]      $	��Top=�61   5^      5_      5`      