   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      I EPlanner.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Planner.Client.View.PagesPlanner.Client.View.Pages 5      .   (Planner.Client.View.Pages.SubjectsViewer   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      9local'clr-namespace:Planner.Client.View.Pages     5        N� Title$  SubjectsViewer��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��250 �6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��2��6"   ���	#FFD6E9F9 �� Orientation$ 
Horizontal=�6M   .+�5      �� $��5,5,0,5q�6   $	��100��6&    #  MahApps.Styles.Button.Hamburger#���   62   ���	#19D5D5D5��6l   �� *OpenCreateCommand+.��5      �� $ Vertical=�6   .+�5      �� $:��4/Assets/InterfaceIcons/icons8-create-document-64.png��6   $��32��6Z   $��32��6e   �� 5      $�� Create��6    $��12(�6/   5      5      �� 5      $��5,5,0,5q�6   $	��100��6&   #���   62   ���	#19D5D5D5��6l   �� *OpenEditCommand+.��5      �� $ Vertical=�6   .+�5       �� $/��)/Assets/InterfaceIcons/icons8-edit-64.png��6   $��32��6O   $��32��6Z   �� 5!      $�� Edit ��6    $��12(�6.   5"      5#      �� 5$      $��1,5,0,5q�6   $	��100��6&   #���   62   ���	#19D5D5D5��6l   �� *DeleteCommand+.��5%      �� $ Vertical=�6   .+�5&      �� $1��+/Assets/InterfaceIcons/icons8-remove-64.png��6   $��32��6Q   $��32��6\   �� 5'      $�� Remove��6    $��12(�6/   5(      5)      �� 5*      ���	#7FA9A9A9$��0,5,0,5q�6/   #��["�6@   �� 5+      $��1,5,0,5q�6   $	��100��6&   #���   62   ���	#19D5D5D5��6l   �� *OpenDialogCommand+.��5,      �� $ Vertical=�6   .+�5-      �� $8��2/Assets/InterfaceIcons/icons8-opened-folder-64.png��6   $��32��6X   $��32��6c   �� 5.      $��
 Open Set ��6    $��12(�62   5/      50      �� 51      $��1,5,0,5q�6   $	��100��6&   #���   62   ���	#19D5D5D5��6l   �� *SaveCommand+.��52      �� $ Vertical=�6   .+�53      �� $/��)/Assets/InterfaceIcons/icons8-save-64.png��6   $��32��6O   $��32��6Z   �� 54      $�� Save ��6    $��12(�6.   55      56      57      &   System.Windows.Controls.DataGrid  59   
   $��1��6      AutoGenerateColumns$
 True��5;         
IsReadOnly$
 True��5<      $��2��5=   I   ��5:      �� *
Subjects+ �� SelectedItem 5=      �� *SelectedSubject+ �� Mode$ TwoWay=�6I   �� 5@   
   $��1��6   $��1��6%     MahApps.Brushes.Gray1#���  62   y�6g   �� *CreatorVisibility+.+�5A      �� $��Create Subject��6   $��Center=�6-   $��28(�6H   $��Segoe UI Semilight)�6V   
�������6v   �� 5D      $��Level��6   $��Center=�6$   
�������6?   �� 5E      $	��230��6   $
��Left=�6"   $��5,0,5,0q�6=   ��5F   
   �� *Level+$ TwoWay=��� 5I      $
��Name��6   $��Center=�6#   
�������6>   �� 5J      $	��230��6   $
��Left=�6"   $��5,0,5,0q�6=   ��5K   
   �� *SubjectName+$ TwoWay=��� 5N      $
��Code��6   $��Center=�6#   
�������6>   �� 5O      $	��230��6   $
��Left=�6"   $��5,0,5,0q�6=   ��5P   
   �� *SubjectCode+$ TwoWay=��� 5S      $��Credits��6   $��Center=�6&   
�������6A   �� 5T      $	��230��6   $
��Left=�6"   $��5,0,5,0q�6=   ��5U   
   �� *	Credits+$ TwoWay=��� 5X      $��GPA Credits��6   $��Center=�6*   
�������6E   �� 5Y      $	��230��6   $
��Left=�6"   $��5,0,5,0q�6=   ��5Z   
   �� *
GPACredits+$ TwoWay=��� 5]      $
��Type��6   $��Center=�6#   
�������6>   �� 5^      $	��230��6   $
��Left=�6#   $��5,0,5,0q�6>   ��6O   �� *SubjectTypes+ 5_   
   �� *SubjectType+$ TwoWay=��� 5b      $��Description��6   $��Center=�6*   
�������6E   �� 5c      $	��230��6   $
��Left=�6"   $��5,0,5,0q�6=   ��5d   
   �� *Description+$ TwoWay=��� 5g        MahApps.Styles.Button.Flat#���  6   $��Create��6J   $	��100��6\   $��Right=�6�   $��	0,15,15,0q�6�   ��6h   �� *CreateCommand+6�   5h      �� 5l   
   $��1��6   $��1��6%   #���  62   y�6g   �� *EditorVisibility+.+�5m      �� $��Edit Subject��6   $��Center=�6+   $��28(�6F   $��Segoe UI Semilight)�6T   
�������6t   �� 5p      $��Level��6   $��Center=�6$   
�������6?   �� 5q      $	��230��6   $
��Left=�6"   $��5,0,5,0q�6=   ��5r      �� *Level+$ TwoWay=��� 5u      $
��Name��6   $��Center=�6#   
�������6>   �� 5v      $	��230��6   $
��Left=�6"   $��5,0,5,0q�6=   ��5w      �� *SubjectName+$ TwoWay=��� 5z      $
��Code��6   $��Center=�6#   
�������6>   �� 5{      $	��230��6   $
��Left=�6"   $��5,0,5,0q�6=   ��5|      �� *SubjectCode+$ TwoWay=��� 5      $��Credits��6   $��Center=�6&   
�������6A   �� 5�      $	��230��6   $
��Left=�6"   $��5,0,5,0q�6=   ��5�      �� *	Credits+$ TwoWay=��� 5�      $��GPA Credits��6   $��Center=�6*   
�������6E   �� 5�      $	��230��6   $
��Left=�6"   $��5,0,5,0q�6=   ��5�      �� *
GPACredits+$ TwoWay=��� 5�      $
��Type��6   $��Center=�6#   
�������6>   �� 5�      $	��230��6   $
��Left=�6#   $��5,0,5,0q�6>   ��6O   �� *SubjectTypes+ 5�      �� *SubjectType+$ TwoWay=��� 5�      $��Description��6   $��Center=�6*   
�������6E   �� 5�      $	��230��6   $
��Left=�6"   $��5,0,5,0q�6=   ��5�      �� *Description+$ TwoWay=��� 5�      #���  6   $��Update��6J   $	��100��6\   $��Right=�6�   $��	0,15,15,0q�6�   ��6h   �� *EditCommand+6�   5�      5�      5�      