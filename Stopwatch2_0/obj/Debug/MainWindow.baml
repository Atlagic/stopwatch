   M S B A M L   `   `   `  ����G  CStopwatch2_0, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Stopwatch2_0Stopwatch2_0  5   	       Stopwatch2_0.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Stopwatch2_0     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      ]� .+�5
   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� -   5        $��mFileSaveAs��5      $��Save _As ...��6.   6D   �� 5      m� 5      -   5        $��	mFileExit��5      $��E_xit��6,   6;   5      m� 5      $��_Tools��6   .@�5      m� -   5        $��mToolsOptions��5      $��
Options...��60   6D   5      m� 5      $��_Help��6   .@�5      m� -   5        $��
mHelpAbout��5      $��_About��6-   6=   5      5      �� 5   
   $��Bottom=�6   .@�5      �� .��5      �� -   5        $��txtSplitTimesCount��5      Split times count: 06L   5      5      � 5   
   $
��Left=�6    � RowDefinitions 5      �� 5      $��* �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6     � ColumnDefinitions 5"      �� 5#      $��* �6#   �� 5$      $��* �6#   .+�5&      �� -   5        $��lstSplitTimes��5&      $��0��6+   $��0��68   $��2��6H   �� 5'      -   5        $��btnStart��5'      $��5,5,5,5q�6%   $��1��66   $��0��6C   $��Start��6S   6c   �� 5(      -   5        $��btnAdd��5(      $��5,5,5,5q�6#   $��1��64   $��1��6A   $	��Add��6Q   6_   �� 5)      -	   5        $��btnStop��5)      $��5,5,5,5q�6$   $��2��65   $��0��6B   {�.  .��5*      ��  �� Orientation$ 
Horizontal=�6   .+�5+      �� $��5q�6    $��10��6+   $��10��66   
���   �6B   �� 5,      $
��Stop��6    5-      5.      �� 5/      -
   5        $��btnReset��5/      $��5,5,5,5q�6%   $��2��66   $��1��6C   $��Reset��6S   6c   50      � 51   
   -   5        $��
grdDisplay��51      
�������.+�52      (� .��53      �� -   5        $��
txtDisplay��53      00:00:00:006;   54      55      56      57      