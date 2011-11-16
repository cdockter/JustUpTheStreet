from django import forms

class PrizeForm(forms.Form):
    name            = forms.CharField(max_length=100)
    description     = forms.CharField(required=False)
    contributions   = forms.FloatField(min_value=10, required=False, initial=10)
    expires         = forms.DateTimeField()
    rule1           = forms.CharField(required=False)
    rule2           = forms.CharField(required=False)
    rule3           = forms.CharField(required=False)
