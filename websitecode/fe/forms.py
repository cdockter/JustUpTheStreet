from django import forms

class PrizeForm(forms.Form):
    prize           = forms.IntegerField(widget=forms.HiddenInput(), required=False)
    name            = forms.CharField(max_length=100)
    description     = forms.CharField(required=False)
    #contribution    = forms.FloatField(min_value=10, required=False, initial=10)
    #expires         = forms.DateTimeField()
    #rule1           = forms.ModelForm #forms.CharField(required=False)
    #rule2           = forms.CharField(required=False)
    #rule3           = forms.CharField(required=False)

class LoginForm(forms.Form):
    username        = forms.CharField(max_length=56)
    password        = forms.CharField(widget=forms.PasswordInput()) 