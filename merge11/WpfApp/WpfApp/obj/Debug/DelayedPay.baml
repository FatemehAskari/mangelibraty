   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.DelayedPay   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   -   5          � WindowStyle$
  None=�5   	    � Title$ 
DelayedPay��5	   	   $	��700��6   $	��900��6)    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         btnClose �� 
TargetType �� Property �� Value��%z   &	        �� 5   
   " ��6!   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 ���� 6,   5      5      .��5      � .+�5   
   ��  �� CornerRadius$ 10��6   $��2��6#   $��2��64   ��5      �� 5      .��5      � 	 � Color$	 #B879D4��6#   
 � Offset$	
 0.0Q�63   6B   � 5      $	 #5256B7��6#   $
 1Q�63   6@   5      5      �� 5"   
   .��5#      �� ��6   �� *DelayedMembership+��5$      �� 5%      .R�5&      �  � RowDefinitions 5'      �� 5(   "   62   �� 5)   "   62    � ColumnDefinitions 5+      �� 5,   "   65   �� 5-   "   65   �� 5.   "   65   �� 5/   "   65   �� 50   "   65   �� 51   "   $	��185 �63   6A   .+�54      �� $��0��6(   $��
First Name��68   $��20,40,20,20q�55   ,   $��	Helvetica)�6A   $��18(�56   ,   ���	#FFFBFBFB$��0��57   ,   $��WrapWithOverflow=�58   ,   $
��Bold"�59   ,   �� 5:      $��1��6(   $��	Last Name��68   $��20,40,20,20q�5;   ,   $��	Helvetica)�6A   $��18(�5<   ,   ���	#FFFBFBFB$��0��5=   ,   $��WrapWithOverflow=�5>   ,   $
��Bold"�5?   ,   �� 5@      $��2��6(   $��Email��68   $��20,40,20,20q�5A   ,   $��	Helvetica)�6A   $��18(�5B   ,   ���	#FFFBFBFB$��WrapWithOverflow=�5C   ,   $
��Bold"�5D   ,   �� 5E      $��3��6(   $��Phone Number��68   $��20,40,20,20q�5F   ,   $��	Helvetica)�6A   $��18(�5G   ,   ���	#FFFBFBFB$��0��5H   ,   $��WrapWithOverflow=�5I   ,   $
��Bold"�5J   ,   �� 5K      $��4��6(   $�� Account Balance��68   $��20,40,20,20q�5L   ,   $��	Helvetica)�6A   $��18(�5M   ,   ���	#FFFBFBFB$��0��5N   ,   $��WrapWithOverflow=�5O   ,   $
��Bold"�5P   ,   �� 5Q      $��5��6(   $��Memebership Date��68   $��20,40,20,20q�5R   ,   $��	Helvetica)�6A   $��18(�5S   ,   ���	#FFFBFBFB$��0��5T   ,   $��WrapWithOverflow=�5U   ,   $
��Bold"�5V   ,   �� 5Y      $��0��6(   $��20,20q�68   $��	Helvetica)�5[   ,   $��18(�6C   ���	#FFFBFBFB$��1��5]   ,   $��WrapWithOverflow=�5^   ,   ��5Z   ,   �� *
_firstName+5^   ,   �� 5_      $��1��6(   $��20,20q�68   $��	Helvetica)�5a   ,   $��18(�6C   ���	#FFFBFBFB$��1��5c   ,   $��WrapWithOverflow=�5d   ,   ��5`   ,   �� *	_lastName+5d   ,   �� 5e      $��2��6(   $��20,20q�68   $��	Helvetica)�5g   ,   $��18(�6C   ���	#FFFBFBFB$��1��5i   ,   $
��Wrap=�5j   ,   ��5f   ,   �� *	_userName+5j   ,   �� 5k      $��3��6(   $��20,20q�68   $��	Helvetica)�5m   ,   $��18(�6C   ���	#FFFBFBFB$��1��5o   ,   $��WrapWithOverflow=�5p   ,   ��5l   ,   �� *_phone+5p   ,   �� 5q      $��4��6(   $��20,20q�68   $��	Helvetica)�5s   ,   $��18(�6C   ���	#FFFBFBFB$��1��5u   ,   $��WrapWithOverflow=�5v   ,   ��5r   ,   �� *
_balance+5v   ,   �� 5w      $��5��6(   $��20,20q�68   $��	Helvetica)�5y   ,   $��18(�6C   ���	#FFFBFBFB$��1��5{   ,   $��WrapWithOverflow=�5|   ,   ��5x   ,   �� *
_memDate+5|   ,   5}      5~      5�      5�      �� 5�   
   -   5        $	��btn��5�      #��[  5�      $��40��5�      $��40��6    $	��Top=�5�      $��
200,0,15,0q�5�      $��Right=�6)   $��1��5�      .��5�      �� $��	close.png��6   $��40��5�      $��40��5�       J� IsManipulationEnabled . $��Right=�5�      $	��Top=�61   5�      5�      5�      