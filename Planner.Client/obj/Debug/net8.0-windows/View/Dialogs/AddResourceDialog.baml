   M S B A M L   `   `   `  ����I  EPlanner.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Planner.Client.View.DialogsPlanner.Client.View.Dialogs  5   	   3    -Planner.Client.View.Dialogs.AddResourceDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Planner.Client.View.Dialogs     5   	     � Title$  DropSelectorDialog��5      $	��240��6,   $	��520��69    � 
ResizeMode$ NoResize=�6E    � ShowInTaskbar$ False��6[    � WindowStyle$ 
ToolWindow=�6q   .��5	      �� .+�5
   
   �� -   5         ��Name$ CaptionTextbox��5
      $
��Test��6,   $��24(�68   $��Segoe UI Semilight)�6F   $��10,5,0,0q�6f   �� 5   
    �� Orientation$ 
Horizontal=�6   $��	15,10,0,0q�6.   .+�5      �� $��Level��6   $��70��6$   �� 5      -   5         ��Name$ LevelSelector��5      $	��400��6-   $
��Left=�6:   6U   5      �� 5   
   $ 
Horizontal=�6   $��	15,10,0,0q�6.   .+�5      �� $��Subject��6   $��70��6&   �� 5      -   5         ��Name$ SubSelector��5      $	��400��6,   $
��Left=�69    �� DisplayMemberPath$ SubjectName��6T   5      �� 5   
   $ 
Horizontal=�6   $��	15,10,0,0q�6.   .+�5      �� $��Category��6   $��70��6'   �� 5      -   5        $ CategorySelector��5      $	��400��61   $
��Left=�6>   5      �� 5   
   $ 
Horizontal=�6   $	��255��6.   $��Right=�6:   $��	0,10,20,0q�6V   .+�5      �� -   5        	 ��Name$	 Ok��5      $
��Okay��6!   $	��120��60   $��10,0,0,0q�6<    (  $MahApps.Styles.Button.Dialogs.Accent#���   6N   6�   �� 5      -   5        $	 Cancel��5      $��Cancel��6%   $	��120��66   $��5,0,0,0q�6B     MahApps.Styles.Button.Flat#���  6S   6�   5      5      5      