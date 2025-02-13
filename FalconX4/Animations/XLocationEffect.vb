﻿Imports System.Runtime.InteropServices

Namespace VisualEffects.Animations.Effects

    Public Class XLocationEffect

        Implements IEffect

        Public WM_SIZE = &H5

        <DllImport("user32.dll", SetLastError:=True)>
        Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInt32) As Boolean
        End Function

        Public SWP_NOSIZE As UInt32 = 1
        Public SWP_ASYNCWINDOWPOS As UInt32 = 16384
        Public SWP_NOACTIVATE As UInt32 = 16
        Public SWP_NOSENDCHANGING As UInt32 = 1024
        Public SWP_NOZORDER As UInt32 = 4

        Public Shared FirstTaskbarPtr As IntPtr = CType(0, IntPtr)
        Public Shared FirstTaskbarPosition As Integer = 0
        Public Shared FirstTaskbarOldPosition As Integer = 0

        Public Function GetCurrentValue(ByVal control As Control) As Integer Implements IEffect.GetCurrentValue
            Return control.Left

        End Function

        Public Sub SetValueX(ByVal control As Control, ByVal originalValue As Integer, ByVal valueToReach As Integer, ByVal newValue As Integer) Implements IEffect.SetValueX

            SetWindowPos(FirstTaskbarPtr, IntPtr.Zero, newValue, 0, 0, 0, SWP_NOSIZE Or SWP_ASYNCWINDOWPOS Or SWP_NOACTIVATE Or SWP_NOZORDER Or SWP_NOSENDCHANGING)

        End Sub

        Public Sub SetValueY(ByVal control As Control, ByVal originalValue As Integer, ByVal valueToReach As Integer, ByVal newValue As Integer) Implements IEffect.SetValueY

            SetWindowPos(FirstTaskbarPtr, IntPtr.Zero, 0, newValue, 0, 0, SWP_NOSIZE Or SWP_ASYNCWINDOWPOS Or SWP_NOACTIVATE Or SWP_NOZORDER Or SWP_NOSENDCHANGING)

        End Sub

        Public Function GetMinimumValue(ByVal control As Control) As Integer Implements IEffect.GetMinimumValue
            Return Int32.MinValue
        End Function

        Public Function GetMaximumValue(ByVal control As Control) As Integer Implements IEffect.GetMaximumValue
            Return Int32.MaxValue
        End Function

        Public ReadOnly Property IEffect_Interaction As EffectInteractions Implements IEffect.Interaction
            Get
                Return EffectInteractions.X
            End Get
        End Property

    End Class

End Namespace