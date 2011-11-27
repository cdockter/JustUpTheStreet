# Create your views here.
from fe.models import *
from fe.forms import *
from django.shortcuts import render_to_response
from django.template import *
from django.http import *
from django.core.context_processors import csrf

def Create(request):
    response = HttpResponse()
    request.POST['name']
    if 'POST' == request.method:
        form = PrizeForm(request.POST)
        
        if form.is_valid():
            prize               = Prize()
            prize.name          = form.cleaned_data['name']
            prize.description   = form.cleaned_data['description']
            prize.creator       = Account.objects.get(user=request.user)
            prize.state         = CreatInitStateObject('2012-12-12')
            prize.save()
            #prize.contributions.add(CreateContrib(prize.creator, form.cleaned_data['contribution'], form.cleaned_data['expires']))
            #prize.save()
            response = HttpResponse(prize.id)
    return response

def CreatInitStateObject(date):
    state         = PrizeState()
    state.name    = 'draft'
    state.expires = date
    state.save()
    return state

def CreateContrib(user, amount, expires):
    contrib = Contribution()
    contrib.contributor = user
    contrib.amount      = amount
    contrib.expires     = expires
    contrib.save()
    return contrib
