   M S B A M L   `   `   `  ����I  EPlanner.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Planner.Client.View.DialogsPlanner.Client.View.Dialogs  5   	   .    (Planner.Client.View.Dialogs.GridSelector   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Planner.Client.View.Dialogs     5   	     � Title$  DropSelectorDialog��5   	   $	��460��6$   $	��500��61    � 
ResizeMode$ NoResize=�6=    � ShowInTaskbar$ False��6S    � WindowStyle$ 
ToolWindow=�6i   .��5	      �� .+�5
   
   �� -   5         ��Name$ CaptionTextbox��5
      $
��Test��6,   $��24(�68   $��Segoe UI Semilight)�6F   $��10,5,0,0q�6f   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ MainGrid��5      $	��450��6%   $	��300��61   $��	15,10,0,0q�6>   $
��Left=�6Q      SelectionMode$ Single=�6l      
IsReadOnly$
 True��6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $	��255��6.   $��Right=�6:   $��	0,10,20,0q�6V   .+�5      �� -   5        	 ��Name$	 Ok��5      $
��Okay��6!   $	��120��60   $��10,0,0,0q�6<    (  $MahApps.Styles.Button.Dialogs.Accent#���   6N   6�   �� 5      -   5        $	 Cancel��5      $��Cancel��6%   $	��120��66   $��5,0,0,0q�6B     MahApps.Styles.Button.Flat#���  6S   6�   5      5      5      