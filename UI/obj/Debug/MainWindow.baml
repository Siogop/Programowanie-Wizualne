   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Pogodski.GunCatalog.UIPogodski.GunCatalog.UI  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   ? ;Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ4clr-namespace:Pogodski.GunCatalog.Core;assembly=CorePogodski.GunCatalog.Core 5   	   S.clr-namespace:Pogodski.GunCatalog.UI.ViewModel Pogodski.GunCatalog.UI.ViewModel  5	   	   '    !Pogodski.GunCatalog.UI.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Pogodski.GunCatalog.UI     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   K
StyleAlias4clr-namespace:Pogodski.GunCatalog.Core;assembly=Core     5   	   E
viewmodels.clr-namespace:Pogodski.GunCatalog.UI.ViewModel     5	   	   -   5        $��Window1��5   5     � Title$  
MainWindow��6	   $	��450��6   $	��800��6)    � 	Resources 5         dataFromEnum S� 
MethodName S� 
ObjectType  System.Enum S� MethodParameters M� TypeName  TextBoxWithErrors �� Property �� Value �� DisplayMemberPath	 �� ElementName
 �� Path �� Triggers P� Property P� Value��%g  &	        &	 s     S� 5   
   $ 	GetValues��62   "  5       5      M� 5      $ StyleAlias:GunType��6   5      �� 5   
   .�5      ��  �@=�ErrorTemplate 5      �� 5      .R�5      ]� ��. .+�5      �� $��Bottom=�6&   $ ErrorContent��6�   ��6>   �� $	 ErrorComponent��$(
 "AdornedElement.(Validation.Errors)�6�   � 5      $
��Left=�6#   .+�5   "   A� $��20��6*   $��20��65   
���  ��
���  ��6c   �� 5   "   
���������6(   �� $	 ErrorComponent��$.
 (AdornedElement.(Validation.Errors).Count�6�   5      �� 5      
���  ��$��2q�6;   ._�5   "   �� $��ErrorComponent��6<   5      5       5!      5#      �� 5$       � ��$	 150��61    5%      P� 5&       �@=�HasError . . �5'      ��  � ��$ 	20 2 2 50q�67   5(      5*      5+      .��5,      �� .@�5-   
   �� $
��Guns��6    � DataContext 5.      7   1Pogodski.GunCatalog.UI.ViewModel.GunListViewModel  5/      .��51      ]� ��. .+�52      �� -   5        $��GunListPanel��52   0   $
��Left=�6   $ Model��6a   ��6D   �� *Guns+ �� SelectedItem 6{   �� *SelectedGun+53      �� 54      $��Bottom=�6    �� Orientation$ 
Horizontal=�65   .+�55      �� ��6   �� *FilterDataCommand+.��6C   Filter6K   �� 56      $	��100��6   ��6-   �� *FilterValue+6M   �� 57      ��6   �� *AddNewGunCommand+.��6B   Add new Gun6O   �� 58      ��6   �� *SaveGunCommand+.��6A   
Save Gun6K   59      � 5:      -   5        $��GunDetailsList��5:       6-   �� *	EditedGun+ � RowDefinitions 5;      �� 5<      $
��Auto �6(   �� 5=      $��* �6(   .+�5?      � $��0��6    � ColumnDefinitions 5@      �� 5A      $
��Auto �6/   6>   �� 5B      $��* �6/   6;    5D      �� 5E      6.   �� 5F      6.   �� 5G      6.   �� 5H      6.   �� 5I      6.   .+�5K      �� $��0��6    .��6-   Model:65   �� 5L      #��[ 6"   $��0��6N   $��1��6[   $	��150��6k   ��6z   �� *Model+�� 5M      $��1��6    .��6-   
Caliber:67   �� 5N      #��[ 6"   $��1��6N   $��1��6[   $	��150��6k   ��6z   �� *	Caliber+�� 5O      $��2��6    .��6-   	Clipsize:68   �� 5P      #��[ 6"   $��2��6N   $��1��6[   $	��150��6k   ��6z   �� *
ClipSize+�� 5Q      $��3��6    .��6-   	Producer:68   �� 5R      #��[ 6#   $��3��6O   $��1��6\   $
 Name��6�   ��6l   �� *	Producers+ 6�   �� *
Producer+�� 5S      $��4��6    .��6-   Type63   �� 5T      #��[ 6#   $��4��6O   $��1��6\   ��6l   ��  �� Source# [   6�   �� *Type+5U      5V      5W      5X      �� 5Y   
   $��	Producers��6    5Z      <   6Pogodski.GunCatalog.UI.ViewModel.ProducerListViewModel  5[      .��5]      ]� ��. .+�5^      �� -   5        $��ProducerListPanel��5^   0   $
��Left=�6   $
 Name��6k   ��6I   �� *	Producers+ 6�   �� *SelectedProducer+5_      �� 5`      $��Bottom=�6   $ 
Horizontal=�65   .+�5a      �� ��6   �� *FilterDataCommand+.��6C   Filter6K   �� 5b      $	��100��6   ��6-   �� *FilterValue+6M   �� 5c      ��6   �� *AddNewProducerCommand+.��6G   Add new Producer6Y   �� 5d      ��6   �� *SaveProducerCommand+.��6F   Save Producer6U   5e      � 5f      -   5        $��ProdDetailsList��5f       6.   �� *EditedProducer+ 5g      �� 5h      $
��Auto �6(   �� 5i      $��* �6(   .+�5k      � $��0��6    5l      �� 5m      $
��Auto �6/   6>   �� 5n      $��* �6/   6;    5p      �� 5q      6.   �� 5r      6.   .+�5t      �� $��0��6    .��6-   Name:64   �� 5u      #��[ 6"   $��0��6N   $��1��6[   $	��150��6k   ��6z   �� *Name+�� 5v      $��1��6    .��6-   
Country:67   �� 5w      #��[ 6"   $��1��6N   $��1��6[   $	��150��6k   ��6z   �� *	Country+5x      5y      5z      5{      5|      5}      