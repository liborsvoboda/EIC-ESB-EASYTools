   M S B A M L   `   `   `  ����P  LEASYTools.AvalonEditB, Version=2.2.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AvalonEditB.CodeCompletionAvalonEditB.CodeCompletion  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089>   8AvalonEditB.CodeCompletion.InsightWindowTemplateSelector   templateSelector.   (AvalonEditB.CodeCompletion.InsightWindow  �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� CornerRadius �� ContentStringFormat �� ContentStringFormat J� SnapsToDevicePixels/   )AvalonEditB.CodeCompletion.OverloadViewer	 � 	ResourcesB  <AvalonEditB.CodeCompletion.CollapseIfSingleOverloadConverter  Key
 �� Triggers P� Property P� Value �� 
TargetName �� RelativeSource �� Path � ColumnDefinitions � RowDefinitions �� Orientation % !collapseIfSingleOverloadConverter �� 	Converter  upDownButtonStyle �� Stretch�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      /cc(clr-namespace:AvalonEditB.CodeCompletion  5      %F  &	        '       '  B    7  7  7  7   7      5      6$   �� 5      "   6	   .�5      ��  �@�SizeToContent$ WidthAndHeight=�6$   �� 5
       � ��$ 1q�6&   �� 5       � ��# � ��6"   �� 5       � ��# � ��6!   �� 5       � ��# � ��6!   �� 5       � ��# � ��6!   �� 5       � ��# � ��6   �� 5       � ��# � ��6    �� 5       � ��# � ��6!   �� 5       � ��$ 1,1,3,1q�6   �� 5       � ��$
 Left=�61   �� 5       � ��$ Center=�6/   �� 5       � �� 5      �� 5      "  6   .R�5      �� #��z��6   # z��5      $ 2,2,2,2��5      #��z��5      #��z��5      ._�5      �� .u�5   	   �� #��z��5   	   #��z��5    	   # z 5!   	   #��z��5"   	   #��z��5#   	   # z 5$   	   5%   	   5&      5'      5)      5*      �� 5-      "   6	   .�5.      ��  � �� 5/      �� 50      "  6   .R�51      � 	 52      ��  53   	   %!collapseIfSingleOverloadConverter 6.   �� 56   	   '��       "  ��6   upDownButtonStyle �57   
   �� 58       � ��
 �����6(   �� 59       � ��$ 2,2,2,2q�6%   �� 5:       � ��$ 9��6#   �� 5;       � ��$ 9��6$   �� 5<       �@J�SnapsToDevicePixels$
 True��61   �� 5=       �@�OverridesDefaultStyle$
 True��63   �� 5>       � �� 5?      �� 5@      " ��6   .R�5A      �� $��bd��6   #��z��5B      $ 2��6?   ._�5C      �� #��z��6    #��z��5D       5E      
 5F      P� 5G       �@J�IsMouseOver$
 true��6.   . �5H      �� $ bd��6    � ��
 ��ح�6=   5I      5K      5M      5O   
   �� 5Q   	   TextBlockTemplate .R�5R   
   �� $
��Wrap=�6   ��6(   ��  �� *TemplatedParent+$ Content�5S   
   5T   	    5V      �� 5W   	   $
��Auto �6   �� 5X   	   $��1* �6    5Z      �� 5[   	   $
��Auto �6   �� 5\   	   $��1* �6   .+�5_      �� $��0��6   $��0��6    $��0,0,4,0q�5`      $ 
Horizontal=�5a      y�5b      ��  �� *TemplatedParent+$ Provider.Count�8   .+�5c   	   �� $��PART_UP��6   8�� .��5d   
   F� 
���   �
���   �"����    �6 �@B �6 � �     	$ UniformToFill=�6P   5e   
   �� 5f   	   $��2,0,2,0q�6   ��5g      ��  �� *TemplatedParent+$ Provider.CurrentIndexText��� 5h   	   $��	PART_DOWN��6   8�� .��5i   
   F� 
���   �
���   �"����        �@B     � � �6 	$ UniformToFill=�6L   5j   
   5k   	   �� 5l      $��0��6   $��1��6&   8�� ��5m      ��  �� *TemplatedParent+$ Provider.CurrentHeader��� 5n      $��1��6   $��0��6&   $��2��66   8�� ��5o      ��  �� *TemplatedParent+$ Provider.CurrentContent�5p      5q      5s      5t      5u      