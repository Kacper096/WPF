   M S B A M L   `   `   `  ����I  EDapperDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DapperDatabaseDapperDatabase  5   	   D @NorthView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:NorthView;assembly=NorthView	NorthView 5   	       DapperDatabase.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:DapperDatabase     5   	   :loc*clr-namespace:NorthView;assembly=NorthView     5   	     � Title$  
MainWindow��5	   	   $	��600��6   $
��1040��6)    � 	Resources 5"         showLeftMenu �� TargetProperty t� From	 t� To g� DecelerationRatio g� Duration  hideLeftMenu  showRightMenu  hideRightMenu��%g  &	        &	 �     &	 :    &	 �    �� 5#   
   .��5$      t� -   5        $ Margin�5$   !   $ 
-182,0,0,0X�6D   $ 0,0,0,0X�6V   $ .9Q�6c   $ 0:0:1D�6z   5%   !   5&      �� 5'   
   .��5(      t� -   5        $ Margin�5(   !   $ 0,0,0,0X�6E   $ 
-182,0,0,0X�6T   $ .9Q�6d   $ 0:0:1D�6{   5)   !   5*      �� 5+   
   .��5,      t� $ Margin�6!   $ 
0,0,-402,0X�6D   $ 0,0,0,0X�6V   $ .9Q�6c   $ 0:0:2D�6z   5-      �� 5.   
   .��5/      t� $ Margin�6!   $ 0,0,0,0X�6D   $  0,0,-402,0X�6S   $ .9Q�6d   $ 0:0:2D�6{   50      51      .��52      ]� .+�53   
   � $	��Top=�6   $��68��6$    � ColumnDefinitions 54      �� 55      $
��auto �6#   �� 56      $��* �6#   �� 57      $
��auto �6#   .+�59      �� -   5        $��DatabaseName��59      $��	Northwind��6(   $��1��6<   $
��auto��6M   $	��175��6[   $��Center=�6g   $��Center=�5:      $��20(�69   $��Italic$�6G      DapperDatabase.Clock  5;      -   5          Name$ Clock��5;      $��2��6)   $	��150��69   $��3,3,3,3q�6E   $��Right=�6W   �� 5<      -   5        $
��show��5<      $
��Show��6!   $��0��60   $��63��6@   $��34��6K   $��Bottom=�6W   $��1,1,1,1q�6�   5=      �� 5>   
   -   5        $��
Button_Bar��5>      	 �� Orientation$	 Vertical=�6'   $	��175��6>   $
��Left=�6J   $��
-182,0,0,0q�6`   $
��Auto=�6t   .+�5?      �� -   5        $��CustomerButton��5?      $��Customer��6+   $��50��6>   $��0,0,5,0q�6g   �� 5@      -   5        $��SubMenuCustomerButton��5@      $y�	Collapsed=�66   .+�5A      �� -	   5        $��ViewDataButton��5A      $
��View��6/   $��50��6>   $��0,0,5,0q�6K   $y�Visible=�6\   6q   �� 5B      -
   5        $��CreateCustomerButton��5B      $��Create��65   $��50��6F   $��0,0,5,0q�6S   $y�Visible=�6d   6y   5C      �� 5E      -   5        $��ProductButton��5E      $��Product��6*   $��50��6<   $��0,0,5,0q�6H   5F      � 5G   
    5H      �� 5I      $��* �6#   �� 5J      $
��auto �6#   .+�5L      � -   5        $��CustomersData��5L      $y�	Collapsed=�6(   $��0��6?   .+�5M      &   System.Windows.Controls.DataGrid  
   AutoGenerateColumns
 . $	��Top=�6N   $
��Left=�6f      
IsReadOnly . ��6   �� 6�   5N      � 5O      -   5        $��
OrdersData��5O      $y�	Collapsed=�6%   $��0��6<   .+�5P        	Order��
 .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6\   $	��Top=�6l   $
��Left=�5Q       . ��5P      �� 5Q   2   5R      �� 5S      -   5        $��	RightMenu��5S      $��1��6*   $��
0,0,-402,0q�6:   $y�Visible=�6N   .+�5T      �� 
�������$��2q�60   $��	0,0,-5,-5q�6D   $��Right=�6W   $
��auto��6n   ._�5U      � -   5        $��CreateCustomer��5U      $��Right=�61   $y�Visible=�6M   $��5,5,15,5q�6b   $
��auto��6t    � RowDefinitions 5V      �� 5W      $
��auto �6,   �� 5X      $
��auto �6,   �� 5Y      $
��auto �6,   �� 5Z      $
��auto �6,   �� 5[      $
��auto �6,   �� 5\      $
��auto �6,   �� 5]      $
��auto �6,   �� 5^      $
��auto �6,   �� 5_      $
��auto �6,   �� 5`      $
��auto �6,    5b      �� 5c      $
��auto �6/   �� 5d      $
��auto �6/   .+�5f      �� $��Create Customer��6    $��2��6:   {�. $��0��6_   $��Center=�6l   $��Center=�6�   $��0,0,0,3q�5g      $
��15.5(�6+   $��SemiBold"�6;   �� 5h      $��Company Name��6    $��1��67   {�. $��0,0,0,3q�6U   �� 5i      $
��auto��6"   $��1��60   $��1��6=   $��Center=�6M   $
��Left=�6o   $��0,0,0,3q�6�   ��6�   ��  �� Mode$ OneWayToSource=� �� Path$ NewCustomer.CompanyName��� 5j      $��
First Name��6    $��2��65   {�. $��0,0,0,3q�6S   �� 5k      $
��auto��6"   $��2��60   $��1��6=   $��Center=�6M   $
��Left=�6o   $��0,0,0,3q�6�   ��6�   �� $ OneWayToSource=�$ 	FirstName��� 5l      $��	Last Name��6    $��3��64   {�. $��0,0,0,3q�6R   �� 5m      $
��auto��6"   $��3��60   $��1��6=   $��Center=�6M   $
��Left=�6o   $��0,0,0,3q�6�   ��6�   �� $ OneWayToSource=�$ LastName��� 5n      $��Country��6    $��5��62   {�. $��0,0,0,3q�6P   �� 5o      $
��auto��6"   $��5��60   $��1��6=   $��Center=�6M   $
��Left=�6o   $��0,0,0,3q�6�   ��6�   �� $ OneWayToSource=�$ NewCustomer.Country��� 5p      $
��City��6    $��6��6/   {�. $��0,0,0,3q�6M   �� 5q      $
��auto��6"   $��6��60   $��1��6=   $��Center=�6M   $
��Left=�6o   $��0,0,0,3q�6�   ��6�   �� $ OneWayToSource=�$ NewCustomer.City��� 5r      $��Address��6    $��7��62   {�. $��0,0,0,3q�6P   �� 5s      $
��auto��6"   $��7��60   $��1��6=   $��Center=�6M   $
��Left=�6o   $��0,0,0,3q�6�   ��6�   �� $ OneWayToSource=�$ NewCustomer.Address��� 5t      $��Buisness Phone��6    $��8��69   {�. $��0,0,0,3q�6W   �� 5u      $
��auto��6"   $��8��60   $��1��6=   $��Center=�6M   $
��Left=�6o   $��0,0,0,3q�6�   ��6�   �� $ OneWayToSource=�$ NewCustomer.Phone��� 5v      $
��auto��6!   $��38��6.   $	��100��6=   $��9��6L   $��0��6Y   $��Center=�6j   $��Center=�6�   $��0,20,0,3q�6�   $��2��5w      $��Create��6-   ��6>   �� *SaveCommand+5x      5y      5z      5{      5|      5}      