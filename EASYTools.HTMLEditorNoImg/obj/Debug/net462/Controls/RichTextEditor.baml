   M S B A M L   `   `   `  ����`  \EASYTools.HTMLEditorNoImg, Version=1.0.0.0, Culture=neutral, PublicKeyToken=cdbe214dd9c00af5E'clr-namespace:EASYTools.HTMLEditorNoImgEASYTools.HTMLEditorNoImg  5      d `PresentationFramework.Classic, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35jMclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.ClassicMicrosoft.Windows.Themes 5      .    (EASYTools.HTMLEditorNoImg.RichTextEditor   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ` \Xceed.Wpf.Toolkit, Version=4.6.24151.15440, Culture=neutral, PublicKeyToken=ba83ff368b7563c62xt)http://schemas.xceed.com/wpf/xaml/toolkit  5      2asis'clr-namespace:EASYTools.HTMLEditorNoImg  5      ZThemesMclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Classic  5      -   5          >�Name$  uxRichTextEditor��5   7    � 	Resources 5	         	BaseImage �� 
TargetType �� Property �� Value �� BasedOn  
BaseButton �� ElementName  formatImageStyle  formatDropDownStyle  buttonComboBoxStyle  formatComboBoxStyle �� 
TargetType J� SnapsToDevicePixels	 � IsSharedSizeScope
 � ColumnDefinitions z� SharedSizeGroup ��Name �� Padding ��Name �� SelectionBoxItemTemplate �� SelectionBoxItem d�Name d� 	IsChecked �� Mode �� RelativeSource F�Name �� Triggers P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value ��Name �� 
IsReadOnly ��Name  �Name! � AllowsTransparency" �� ClearTypeHint# ��Name$ ��Name-  'System.Windows.Input.KeyboardNavigation%   DirectionalNavigation& P� 
SourceName  rtbContextMenu' �� 	StaysOpen( m� Command) � ToolTip* m� Icon  ToolBarStyle+ �� Triggers  ToolBarControlTemplate1, �Name- �� 	ClickMode. c� HasOverflowItems/ � FocusVisualStyle0 �� EndPoint1 �� 
StartPoint2 � Color3 � Offset4 �� CornerRadius5 �� Binding6 �� Value7 � 	StaysOpen5  /Microsoft.Windows.Themes.SystemDropShadowChrome8  Name9   Color: b�Name;   TabNavigation< b� 	WrapWidth=   TabIndex> n�Name? �� HeaderStringFormat@ �� ContentStringFormatA a�NameB K� IsItemsHost��%�>  &	        '�� J     7   &	 g     &	 M    7  &	 o    7  &	 �    7  &	 S    &	 C    &	 �%    &	 �&    �� 5
      " ��6   .�5      ��  � ��$
 None=�6   5      �� 5      8   " ��6/   �� 5      " ��6   .�5      ��  � ��$ 28��6   �� 5       � ��$
 Auto��6   �� 5       � ��$ 0q�6   �� 5       � ��$ 1q�6   �� 5       � �� 6%   �� $ mainRTB��5      �� 5      8   " ��60   6M   �� 5      8   " ��60   .�5      ��  � ��$
 Auto��6   �� 5       � ��$ 0q�6   5      �� 5      8   " ��6L   .�5      ��  � ��$
 Auto��6   �� 5       � ��$ 0q�6   5      �� 5       " ��6&   .�5!      ��  �@�FocusVisualStyle 6(   Z� �� 5"       � ��# � ��6"   �� 5#       � �� 6"   Z� �� 5$       � �� 6#   Z� �� 5%       � ��$ 0q�6'   �� 5&       � ��$ 0q�6   �� 5'       � ��$ 0q�6   �� 5(       � ��$
 Auto=�6B   �� 5)       � ��$
 Auto=�6@   �� 5*       � �� . 65   �� 5+       �@��PanningMode$
 Both=�60   �� 5,       �@��IsFlicksEnabled .  6.   �� 5-       � ��$ Center=�6+   �� 5.       � ��$ Center=�6)   �� 5/       � ��$ 18��6!   �� 50       � �� 51      �� 52      " ��6   .R�53      �  . .+�54   	   � 	 . 
 55   
   �� 56      $��* �6   �� 57      $ ComboBoxButton��6   $
��Auto �6=   .+�59   
   �� $ 
Background��6   #��z��6%   �� 5:   
   $ SelectedContentBorder��6   $ 3,0,0,0q�60   ._�5;      �� $ ContentSite��6   #��z 61   #��z 6n   #��z��6�   # z 6�   $��Center=�6�   5<      �� 5=   
   $ Border��6   #��z��6!   #��z��6M   $��2��6�   d� 5>   
   $ DropDownButton��6   
�������$��1q�6C   $��2��6W    6k   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+��5?      �� 5@      " d�6   .�5A      ��  � ��$ 0��6(   �� 5B       � ��$ 0��6)   �� 5C       � ��$
 Auto��6%   �� 5D       � ��
 ���� 6*   �� 5E       � |� .  6)   �� 5F       �@��	ClickMode$ Press=�6)   �� 5G       � �� 5H      �� 5I      " d�6   .R�5J      � 
������ 
 5K      �� 5L      $��* �6#   �� 5M      $ ComboBoxButton��6#   $
��Auto �6D   .+�5O      �� $ Chrome��6   #��z��6(   #��z��6T   #��z��6�   $��1��6�    . $��13��6�   ._�5P      F� $ ArrowDownPath��6   "����%&     � ��     �`�S ��- 	
���   �$��Center=�6V   5Q      5R       5S      P� 5T       � {� .  . �5U      �� $ Chrome��60    6D   Z�  � ��5V      ]� 5W       5X      �� 5Y       �@J�IsMouseOver . 64   �� 5Z       �@d�	IsChecked$ FalseY�62   ./�5\      �� $ Chrome��6/    � �� �	#FFC2E0FF6C   5]      P� 5^       �@d�	IsChecked$
 TrueY�6.   . �5_      �� $ Chrome��60    � �� �	#FF3399FF6D   5`      P� 5a       � �� . . �5b      �� $ Chrome��6/    � �� �	#FF99CCFF6C   5c      P� 5d       � {� .  . �5e      �� $ ArrowDownPath��6)    � �� �	#FFB5B2B56D   5f      5h      5j      5k      5m      �� 5n   
   $ PART_EditableTextBox��6   $��1,1,0,1q�6�   $��18��6�   #��z��6�   $y�	Collapsed=�6�   $��Center=�6�    60   �� *
IsReadOnly+ �� *TemplatedParent+.��6�   ��5o      �� 5p      " ��6   .�5q      ��  �@�OverridesDefaultStyle . 65   �� 5r       �@J�	AllowDrop . 6)   �� 5s       � ��$ 0��6(   �� 5t       � ��$ 0��6)   �� 5u       �@�FocusVisualStyle 60   Z� �� 5v       �@��PanningMode$ VerticalFirst=�68   �� 5w       �@��IsFlicksEnabled .  66   �� 5x       � �� 5y      �� 5z      " ��6   .R�5{      �� $ PART_ContentHost��6   
������ |�.  $��Hidden=�6b   $��Hidden=�6�   5|      5~      5      .��5�      5�      5�   
   � 5�   	   $  
PART_Popup��6   ! . |�.  #��� .�6�   $��Bottom=�6�   ��6O   �� *IsDropDownOpen+ �� *TemplatedParent+.��5�   
   �� $ DropDownBorder��6   $��0q�6@   #��z��6T   $��0q�6~   $ 0q�6�   ��6)   Z� ._�5�      �� $ DropDownScrollViewer��6   .��5�      � $" Enabled=�6   .+�5�      �� $
��Left=�6   $��0��6/   $	��Top=�6:   $��0��6R   .+�5�      �� $# 
OpaqueRect��6   ��6,   �� *
Background+$ DropDownBorder����6d   �� *ActualHeight+$ DropDownBorder����6�   �� *ActualWidth+$ DropDownBorder��5�      �� 5�      $$ ItemsPresenter��6   $% 	Contained=�64   5�      5�      5�      5�   
   5�   	    5�      P� 5�   	    � {� .  . �5�   
   �� # � ��6'    � ���� 5�   
   $ 
Background��6'    � �� �	#FFF7F7F76?   �� 5�   
   $ 
Background��6,    � ��$ 2��6D   �� 5�   
   $ Border��6(    � �� �	#FFB5B2B56<   5�   
   ]� 5�   	    5�   
   �� 5�       �@J�IsKeyboardFocusWithin . 66   �� 5�       �@��IsDropDownOpen .  6/   �� 5�       �@��
IsEditable .  6+   ./�5�   
   �� $ SelectedContentBorder��6'   # � ��6J    � ��5�   
   P� 5�   	    �@��
IsEditable . . �5�   
   �� $ DropDownButton��6'    6C   Z�  � ���� 5�   
   $ ContentSite��6'    � y�$ 	Collapsed=�6@   �� 5�   
   $ PART_EditableTextBox��6'    � y�$ Visible=�6I   5�   
   P� 5�   	    �@J�IsMouseOver . . �5�   
   �� $ DropDownButton��6(    � �� �	#FF3399FF6D   �� 5�   
   $ DropDownButton��6'    � �� �	#FFC2E0FF6C   �� 5�   
   $ Border��6(    � �� �	#FF3399FF6<   5�   
   P� 5�   	    �@J�IsKeyboardFocusWithin . . �5�   
   �� $ DropDownButton��6(    � �� �	#FF3399FF6D   �� 5�   
   $ DropDownButton��6'    � �� �	#FFC2E0FF6C   �� 5�   
   $ Border��6(    � �� �	#FF3399FF6<   5�   
   P� 5�   	    �@��HasItems .  . �5�   
   �� $ DropDownBorder��6&    � ��$ 95��6B   5�   
   ]� 5�   	    5�   
   �� 5�       �@��
IsGrouping . 6+   �� 5�      " �@%�IsVirtualizingWhenGrouping .  6M   ./�5�   
   ��  � �� .  6:   5�   
   ]� 5�   	    5�   
   �� 5�       �@J�IsKeyboardFocusWithin . 66   �� 5�       �@��IsDropDownOpen .  6/   �� 5�       �@��
IsEditable .  6+   ./�5�   
   �� # � ��6'    � ��5�   
   P� 5�   	    �@��
IsEditable . . �5�   
   ��  � ��$ 2q�6$   �� 5�   
    � �� .  6&   5�   
   P� 5�   	   $& DropDownScrollViewer��6-    � �� .  . �5�   
   �� $ 
OpaqueRect��6'    6?   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5�   
   $ 
OpaqueRect��6(    6@   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5�   
   5�      5�      5�      �� 5�      ' .  .@�5�      m� $( ApplicationCommands.Cut��6   $	) Cut��60   * 5�      �� 5�      $��Images/cut.png��6   5�      m� 5�      $( ApplicationCommands.Copy��6   $
) Copy��61   * 5�      �� 5�      $��Images/page_copy.png��6   5�      m� 5�      $( ApplicationCommands.Paste��6   $) Paste��62   * 5�      �� 5�      $��Images/page_paste.png��6   5�      m� 5�      $( ApplicationCommands.Undo��6   $
) Undo��61   * 5�      �� 5�      $��Images/editundo.png��6   5�      m� 5�      $( ApplicationCommands.Redo��6   $
) Redo��61   * 5�      �� 5�      $��Images/editredo.png��6   5�      m� 5�      $ ( EditingCommands.ToggleBold��6   $
) Bold��63   * 5�      �� 5�      $��Images/text_bold.png��6   5�      m� 5�      $"( EditingCommands.ToggleItalic��6   $) Italic��65   * 5�      �� 5�      $��Images/text_italic.png��6   5�      m� 5�      $%( EditingCommands.ToggleUnderline��6   $) 	Underline��68   * 5�      �� 5�      $��Images/text_underline.png��6   5�      m� 5�      $&(  EditingCommands.IncreaseFontSize��6   $) 	Grow Font��69   * 5�      �� 5�      $"��Images/charactergrowfont.png��6   5�      m� 5�      $&(  EditingCommands.DecreaseFontSize��6   $) Shrink Font��69   * 5�      �� 5�      $$��Images/charactershrinkfont.png��6   5     m� 5     $#( EditingCommands.ToggleBullets��6   $) Bullets��66   * 5     �� 5     $"��Images/text_list_bullets.png��6   5     m� 5     $%( EditingCommands.ToggleNumbering��6   $) 	Numbering��68   * 5	     �� 5
     $"��Images/text_list_numbers.png��6   5     m� 5     $( EditingCommands.AlignLeft��6   $) 
Align Left��62   * 5     �� 5     $ ��Images/text_align_left.png��6   5     m� 5     $!( EditingCommands.AlignCenter��6   $) Align Center��64   * 5     �� 5     $"��Images/text_align_center.png��6   5     m� 5     $ ( EditingCommands.AlignRight��6   $) Align Right��63   * 5     �� 5     $!��Images/text_align_right.png��6   5     m� 5     $"( EditingCommands.AlignJustify��6   $) Align Justify��65   * 5     �� 5     $#��Images/text_align_justify.png��6   5      m� 5!     $)( #EditingCommands.IncreaseIndentation��6   $) Increase Indent��6<   * 5"     �� 5#     $��Images/text_indent.png��6   5%     m� 5&     $)( #EditingCommands.DecreaseIndentation��6   $) Decrease Indent��6<   * 5'     �� 5(     $#��Images/text_indent_remove.png��6   5*     5+     �� 5,     " c�6   + 5-     P� 5.      � {� .  . �5/     ��  � y�$ 	Collapsed=�6$   50     P� 51      � {� . . �52     ��  � y�$ Visible=�6$   53     55     �� 56     " c�64   .R�57     � $
, Grid��6
   $��0q�6    . .+�58     � $, OverflowGrid��6   $��Right=�6!   .+�59     d� $ OverflowButton��6   $- Press=�6,   #{�z. 6�   / 6>   Z�  6Z   �� *IsOverflowOpen+$ TwoWay=� �� *TemplatedParent+��5:     �� 5;  	   " d�6   .�5<  
   ��  � �� 5=     �� 5>     $	0 0,1&�6    $	1 0,0&�6/   .��5?     � $2 	#FFE6E6E6��6   $3 0Q�6,   � 5@     $2 	#FFD2D2D2��6   $	3 0.5Q�6,   � 5A     $
2 Gray��6   $3 1Q�6'   5B     5D     �� 5E  
    � ��$ 0��6&   �� 5F  
    � ��$ 0��6%   �� 5G  
    � �� 5H     �� 5I     " d�6   .R�5J     �� $ Bd��6   #��z��6    $4 0��6J    . ._�5K     �� $��Right=�6   $��7��61   $��7,2,2,2q�6<    . $��Bottom=�6h   $��6��6�   .+�5L     F� ����@B `� р�[ `� 	
�������6(   F� 5M     ����     � �@KL  � 	#��z��6(   F� 5N     "���� �  	= Ѡ.c  	= ��g5 ��j 	
�������6/   F� 5O     "�����^����- �`�S ��- Ѡ%& ��[ 	#��z��60   5P     5Q      5R     P� 5S      �@J�IsMouseOver . . �5T     �� $ Bd��6,    � �� �	#FFB6BDD26<   5U     P� 5V      �@J�IsKeyboardFocused . . �5W     �� $ Bd��6,    � �� �	#FFB6BDD26<   5X     P� 5Y      � {� .  . �5Z     ��  � �� �	#FFA0A0A06,   5[     5]     5_     + 5`  
   �� 5a     5 6   �� 6 true6+   .a�5b     ��  � ��# � ��6)   5c     5e  
   5g     � 5h     $  OverflowPopup��6   ! . |�.  #��� .�6�   $��Bottom=�6�   7 .  ��6P   �� *IsOverflowOpen+ �� *TemplatedParent+.��5i       $
8 Shdw��6&   $9 Transparent��64   ._�5j  	   �� $ ToolBarSubMenuBorder��6   ���	#FF666666$��1q�6F   ���	#FFF9F8F7$" Enabled=�6q   ._�5k  
   b� $: PART_ToolBarOverflowPanel��6   $% Cycle=�6B   |�. $��2q�6�   # z 6�   $; Cycle=�6�   $	< 200Q�6  / 6s   Z� 6  5l  
   5m  	   5n     5o     �� 5p     $ MainPanelBorder��6   #��z��6&   #��z��6R   #��z��6�   # z��6�   ��5q     �� 5r     " ��6   .�5s  	   ��  � ��$ 0,0,16,0q�6"   �� 5t  	    �@��CornerRadius$ 0��6(   + 5u  	   �� 5v  
   5 6   �� 6 true6*   .a�5w     ��  �@��CornerRadius$ 0��6*   5x     5z  	   ._�5|     ]� $= 1��6   $; Local=�61   .+�5}     n� $> ToolBarThumb��6   $y�	Collapsed=�6$   �� 5~     $ ToolBarHeader��6   #��z��60   #��z��6c   #@ z? 6�   $��Header��6�   $��Center=�6�   $	��4,0q�6�   # z 6  $��Center=�6>  a� 5     $A PART_ToolBarPanel��6   B . $��0,1,2,2q�6C   # z 6T   5�     5�     5�      5�     P� 5�      �@c�IsOverflowOpen . . �5�     �� $ ToolBarThumb��6#    � {� .  6=   5�     P� 5�      6    Z�  � ��. �5�     �� $ ToolBarHeader��6$    � y�$ 	Collapsed=�6?   5�     P� 5�      �@`�IsLocked . . �5�     �� $ ToolBarThumb��6$    � y�$ 	Collapsed=�6>   5�     P� 5�     $& OverflowPopup��6'    �@�HasDropShadow . . �5�     �� $
 Shdw��6     � ��$ 0,0,5,5q�62   �� 5�     $
 Shdw��6-    �@J�SnapsToDevicePixels . 6?   �� 5�     $
 Shdw��6    �@ Color$ 	#71000000��61   5�     P� 5�      �@c�Orientation$ Vertical=�6%   . �5�     �� $
 Grid��6     � ��$ 1,3,1,1q�62   �� 5�     $ OverflowButton��6    � �� 5�     �� 5�  	   " d�6   .�5�  
   ��  � �� 5�     �� 5�     $	0 1,0&�6    $	1 0,0&�6/   .��5�     � $2 	#FFE6E6E6��6   $3 0Q�6,   � 5�     $2 	#FFD2D2D2��6   $	3 0.5Q�6,   � 5�     $
2 Gray��6   $3 1Q�6'   5�     5�     �� 5�  
    � ��$ 0��6&   �� 5�  
    � ��$ 0��6%   �� 5�  
    � �� 5�     �� 5�     " d�6   .R�5�     �� $ Bd��6   #��z��6    $4 0��6J    . ._�5�     �� $��Right=�6   $��6��61   $��2,7,2,2q�6<    . $��Bottom=�6h   $��7��6�   .+�5�     F� ����`� @B �`� ��[ 	
�������6(   F� 5�     ���� �     � � @KL 	#��z��6(   F� 5�     "�����g5  � ���j �g5 � 	= �.c 	
�������61   F� 5�     "������- �^��р�[ �%& ���- `�S 	#��z��60   5�     5�      5�     P� 5�      �@J�IsMouseOver . . �5�     �� $ Bd��6,    � �� �	#FFB6BDD26<   5�     P� 5�      �@J�IsKeyboardFocused . . �5�     �� $ Bd��6,    � �� �	#FFB6BDD26<   5�     P� 5�      � {� .  . �5�     ��  � �� �	#FFA0A0A06,   5�     5�     5�     + 5�  
   �� 5�     5 6   �� 6 true6+   .a�5�     ��  � ��# � ��6)   5�     5�  
   5�     �� 5�     $ ToolBarThumb��6     � ��$ 10��6:   �� 5�     $ ToolBarThumb��6    � ��$
 Auto��69   �� 5�     $ ToolBarThumb��6     � ��$ 	-1,-3,0,0q�6:   �� 5�     $ ToolBarThumb��6!    � ��$ 5,6,6,1q�6;   �� 5�     $ ToolBarHeader��6     � ��$ 0,0,0,4q�6;   �� 5�     $ PART_ToolBarPanel��6     � ��$ 1,0,2,2q�6?   �� 5�     $ ToolBarThumb��6(    � ��$	 Top=�6B   �� 5�     $ ToolBarHeader��6(    � ��$	 Top=�6C   �� 5�     $ OverflowGrid��6-    � ��$ Stretch=�6G   �� 5�     $ OverflowGrid��6+    � ��$ Bottom=�6E   �� 5�     $ OverflowPopup��6#    � ��$ Right=�6>   �� 5�     $ MainPanelBorder��6     � ��$ 0,0,0,11q�6=   �� 5�      � �� 5�     �� 5�  	   $	0 1,0&�6   $	1 0,0&�6,   .��5�  
   � $2 	#FFE2E0DB��6   $3 0Q�6)   � 5�  
   $2 	#FFEAE8E4��6   $	3 0.5Q�6)   � 5�  
   $2 	#FFD5D2CA��6   $	3 0.9Q�6)   � 5�  
   $2 	#FFDBD8D1��6   $3 1Q�6)   5�  
   5�     5�     P� 5�      � {� .  . �5�     �� # � ��6$    � ��5�     5�     5�     .��5�     � ��6   �� *BorderBrush+$ uxRichTextEditor��C � RowDefinitionsC 5�     �� 5�     -   5        D ��Name$D menuRow��5�     $
��Auto �6$   �� 5�     -   5        $D 
contentRow��5�     $��* �6'   .+�5�     c� -   5        E c�Name$E mainToolBar��5�     $��0��5�     $��30��6   F `� IsLockedF . $	��Top=�5�     #���  5�     #���  5�     {�5�     �� *IsToolBarVisible+$ uxRichTextEditor����5�     �� *BorderBrush+$ uxRichTextEditor����5�     �� *
Foreground+$ uxRichTextEditor����5�     �� *BorderBrush+$ uxRichTextEditor����5�     �� *BorderThickness+$ uxRichTextEditor��.@�5�     �� #��[ 6   $��ApplicationCommands.Cut��66   $	) Cut��6X   .��5�     �� $��Images/cut.png��6   5�     �� 5�     #��[ 6   $��ApplicationCommands.Copy��66   $
) Copy��6Y   .��5�     �� $��Images/page_copy.png��6   5�     �� 5�     #��[ 6   $��ApplicationCommands.Paste��66   $) Paste��6Z   .��5�     �� $��Images/page_paste.png��6   5�     �� 5�     #��[ 6   $��ApplicationCommands.Undo��66   $
) Undo��6Y   .��5�     �� $��Images/editundo.png��6   5�     �� 5�     #��[ 6   $��ApplicationCommands.Redo��66   $
) Redo��6Y   .��5�     �� $��Images/editredo.png��6   5�     �� 5      �� 5     $	��2,0q�6   $ 0q�6   ._�5     �� -   5        $) Select Font��5     $	��100��5     G �� 
IsEditableG .  H �� 
IsReadOnlyH . I �� SelectedIndex$I 0��5     ��5     �� *AvailableFonts+$ uxRichTextEditor��5     5	     �� 5
     #��[ 6   $&�� EditingCommands.IncreaseFontSize��66   $) 	Grow Font��6a   .��5     �� $"��Images/charactergrowfont.png��6   5     �� 5     #��[ 6   $&�� EditingCommands.DecreaseFontSize��66   $) Shrink Font��6a   .��5     �� $$��Images/charactershrinkfont.png��6   5     �� 5     �� 5     #��[ 6   $ ��EditingCommands.ToggleBold��66   $
) Bold��6[   .��5     �� $��Images/text_bold.png��6   5     �� 5     #��[ 6   $"��EditingCommands.ToggleItalic��66   $) Italic��6]   .��5     �� $��Images/text_italic.png��6   5     �� 5     #��[ 6   $%��EditingCommands.ToggleUnderline��66   $) 	Underline��6`   .��5     �� $��Images/text_underline.png��6   5     #  Xceed.Wpf.Toolkit.ColorPicker  5     -   5        J   ShowDropDownButtonJ . $) Select font color��5  .   K   ShowAvailableColorsK .  $��40��6�   �� 5     #���  6   .@�5     �� L �� 
IsSelectedL . .��5     �� #��[ 6   $��EditingCommands.AlignLeft��6;   $) 
Align Left��6_   .��5     �� $ ��Images/text_align_left.png��6   5     5      �� 5!     .��5"     �� #��[ 6   $!��EditingCommands.AlignCenter��6;   $) Align Center��6a   .��5#     �� $"��Images/text_align_center.png��6   5$     5%     �� 5&     .��5'     �� #��[ 6   $ ��EditingCommands.AlignRight��6;   $) Align Right��6`   .��5(     �� $!��Images/text_align_right.png��6   5)     5*     �� 5+     .��5,     �� #��[ 6   $"��EditingCommands.AlignJustify��6;   $) Align Justify��6b   .��5-     �� $#��Images/text_align_justify.png��6   5.     5/     50     �� 51     �� 52     #��[ 6   $#��EditingCommands.ToggleBullets��69   $) Bullets��6a   .��53     �� $"��Images/text_list_bullets.png��6   54     �� 55     #��[ 6   $%��EditingCommands.ToggleNumbering��69   $) 	Numbering��6c   .��56     �� $"��Images/text_list_numbers.png��6   57     �� 58     �� 59     #��[ 6   $)��#EditingCommands.IncreaseIndentation��69   $) Increase Indent��6g   .��5:     �� $��Images/text_indent.png��6   5;     �� 5<     #��[ 6   $)��#EditingCommands.DecreaseIndentation��69   $) Decrease Indent��6g   .��5=     �� $#��Images/text_indent_remove.png��6   5>     �� 5?     �� 5@     -   5        M ��Name$M 
insertLink��5@     #��[ 6    $) Insert link��6M   .��5A     � .+�5B     �� $��Images/world_link.png��6   � 5C     -   5        $  uriInputPopup��5C     7 .  N � PlacementTargetN 66   �� $ 
insertLink��$ OneWay=�.��5D     �� O �� Orientation$O 
Horizontal=�6   
�������.+�5E  	   �� -	   5        $ uriInput��5E  "   $��2,2,0,2q�6   $	��100��64   6@   �� 5F  	   -
   5        $M 	uriSubmit��5F     $	��0,2q�6   $) OK��6G   .��5G  
   �� $��Images/tick.png��6   5H  
   �� 5I  	   -   5        $M 	uriCancel��5I  !   $��0,2,2,2q�6   $) Cancel��6K   .��5J  
   �� $��Images/cross.png��6   5K  
   5L  	   5M     5N     5O     5P     �� 5Q     $��1��6   $��0,1,0,0q�6   .��5R     �� -   5        P ��Name$P mainRTB��5R     Q �� 
AcceptsTabQ . $	��100��5U     R � ContextMenu#R �  5W     4   .EASYTools.HTMLEditorNoImg.RichTextBoxAssistantS   BoundDocumentS 5T     �� *Text+$ uxRichTextEditor�� 5V     �� *
IsReadOnly+$ uxRichTextEditor����5Y     �� *
Background+$ uxRichTextEditor����5Z     �� *
Foreground+$ uxRichTextEditor����5[     �� *BorderBrush+$ uxRichTextEditor����5\     �� *BorderThickness+$ uxRichTextEditor��5^     5_     5`     