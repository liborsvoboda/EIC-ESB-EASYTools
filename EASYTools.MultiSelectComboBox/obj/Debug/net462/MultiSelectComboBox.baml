   M S B A M L   `   `   `  ����!  EASYTools.MultiSelectComboBox-    'MultiSelectComboBox.MultiSelectComboBox   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .��5      �� -   5          ��Name$  MultiSelectCombo��5   	   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5   	    � OverridesDefaultStyle . ��. $
��Auto=�5
   	   $
��Auto=�5   	    J� SnapsToDevicePixels . ��5   
   �� 5      .R�5      �� -   5        ��5      �� *Title+ d� 	IsChecked 5      ��  �� Path$ 
IsSelected� �� Mode$ TwoWay=�
 � Tag 5      �� *FindAncestor+ �� AncestorType" ��5      ��5   
   �� 5      	 �� 
TargetType"	 ��6   .R�5      � .+�5      d� $��ToggleButton��5      $��2��5      $
��Left=�5      
 �� 	ClickMode$
 Press=�5      |�.  ��5       �� $
 Text�$ TwoWay=� �� RelativeSource ��  �� Mode$ FindAncestor=�$ UserControlL� 5"      �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+� 5#      $��Popup��5$       � AllowsTransparency . |�.   �� IsDropDownOpen#��z 5'      $��Bottom=�5(      $��Slide=�5)      .��5*      � $��DropDown��5+       � ActualWidth#��z 5,       �� MaxDropDownHeight#��z 5-       . .+�5/      ��  ��Name$ DropDownBorder��50   !   
���   �$��1q�52   !   �� 53      $��4,6,4,6q�54   !    .  � DataContext 55   !   �� .��57   "   ��  K� IsItemsHost . -  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation$ 	Contained=�6@   58      59      5:      5;       �� Triggers 5<      P� 5=       P� Property �@��HasItems P� Value .  . �5>      ��  �� 
TargetName$ DropDownBorder��6!    �� Property � �� �� Value$ 95��6R   5?      P� 5@       P� 
SourceName$ Popup��6    �@�AllowsTransparency . . �5A      �� $ DropDownBorder��6!    �@��CornerRadius$ 4��6U   �� 5B      $ DropDownBorder��6!    � ��$ 0,2,0,0q�6O   5C      5E      5G      5H      