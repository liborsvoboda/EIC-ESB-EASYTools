   M S B A M L   `   `   `  ����_  [EASYTools.HTMLFullEditor, Version=1.2.3.1, Culture=neutral, PublicKeyToken=cdbe214dd9c00af5S.clr-namespace:EASYTools.HTMLFullEditor.Dialogs EASYTools.HTMLFullEditor.Dialogs  5      M+clr-namespace:EASYTools.HTMLFullEditor.CodeEASYTools.HTMLFullEditor.Code  5      ]3clr-namespace:EASYTools.HTMLFullEditor.Localization%EASYTools.HTMLFullEditor.Localization  5      2    ,EASYTools.HTMLFullEditor.Dialogs.ImageDialog   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @local.clr-namespace:EASYTools.HTMLFullEditor.Dialogs     5      <code+clr-namespace:EASYTools.HTMLFullEditor.Code     5      Dresx3clr-namespace:EASYTools.HTMLFullEditor.Localization     5      $	��600��5      $	��407��5	        � Title  5      5  /EASYTools.HTMLFullEditor.Code.ResourceExtension     Member$% resx:ResourceManager.Text_Image�� � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $? 9/EASYTools.HTMLFullEditor;component/Resources/Styles.xaml?�6%   %    5      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      �� 5      $��40 �6   .+�5   
   � $��0��6   $��0��6   $��2��6,    5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5       $
��Auto �6#   .+�5#      �� -   5        $��0��5#      ��6$     $) #resx:ResourceManager.ImageForm_Path�� �� Target 6i   ��  �� ElementName$ TxtPath��6�   �� 5$      -   5        $��TxtPath��5$   &   $��1��6   	 �� 
IsReadOnly	 . ��65   �� 
 �� Path$
 	ImagePath� �� Mode$ OneWay=�6b   �� 5%      -   5        $��2��5%      ��6%     $&  resx:ResourceManager.Form_Browse��6}   5&      �� 5(   
   $��1��6   $��0��6   
�������$��1q�6F   
�������._�5)      � .+�5*      �� $��Center=�6   $��Center=�67   
���OO/���6o     *(&resx:ResourceManager.ImageForm_Preview+�� 5+      -   5         ��Name$ PreviewScroll��5+      $
��Auto=�66   $
��Auto=�6[   .��5,      �� -   5        $��ImagePreview��5,   M   $��Uniform=�6;   ��6   �� *ImageSource+6M   5-      5.      5/      � 51   
   $��1��6   $��1��6    52      �� 53      $
��Auto �6#   �� 54      $��* �6#   �� 55      $
��Auto �6#   �� 56      $��* �6#    58      �� 59      $��30 �6    �� 5:      $��30 �6    �� 5;      $��30 �6    �� 5<      $��30 �6    �� 5=      $��* �6    .+�5@      �� -   5        $��0��5@      $��0��6!   ��61     *&$resx:ResourceManager.ImageForm_Title+ 6p   �� $ TxtTitle��6�   �� 5A      -   5        $��TxtTitle��5A   G   $��0��6   $��1��6#   $��3��63   ��6W   �� *
ImageTitle+{�6s   �� *	IsSuccess+�� 5C      -   5        $��1��5C      $��0��6!   ��61     *&$resx:ResourceManager.ImageForm_Width+ 6p   �� $ TxtWidth��6�   �� 5D      -	   5        $��TxtWidth��5D   3   $��1��6   $��1��6#   ��6C   �� *
ImageWidth+{�6_   �� *	IsSuccess+�� 5E      -
   5        $��1��5E      $��2��6!   ��61     *'%resx:ResourceManager.ImageForm_Height+ 6q   �� $ 	TxtHeight��6�   �� 5F      -   5        $��	TxtHeight��5F   3   $��1��6   $��3��6#   ��6D   �� *ImageHeight+{�6a   �� *	IsSuccess+�� 5H      -   5        $��2��5H      $��0��6!   ��61     $) #resx:ResourceManager.ImageForm_Size�� 6v   �� $ 
SliderSize��6�   �� 5I      -   5        $��
SliderSize��5I   2   $��2��6   $��1��6"   $��3��6D    � Minimum$ 1Q�6X    � Maximum$	 100Q�6d    �� TickPlacement$ BottomRight=�6r    �� TickFrequency$ 5Q�6�    � Value 6�   �� *ReduceCoefficient+{�6�   �� *	IsSuccess+�� 5K      $��3��6   $��1��6$   $��3��64    d� 	IsChecked 6H   �� *DoPhysicalResize+.��5L      �� ��6     $5 /resx:ResourceManager.ImageForm_DoPhysicalResize��5M      5N      �� 5P   
   $��2��6   $��0��6"   .+�5Q      ��  6   �� *ShowRealSize+.��5R      �� ��6     $1 +resx:ResourceManager.ImageForm_ShowRealSize��5S      5T      �� 5V   
   $��2��6   $��0��6   $��2��6.   ._�5W      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $��Bottom=�6N   .+�5X      �� -   5        ��5X        $" resx:ResourceManager.Form_OK��{�6i   �� *	IsSuccess+�� 5Y      -   5         �� IsCancel . ��5Y        $&  resx:ResourceManager.Form_Cancel��6k   5Z      5[      5\      5]      