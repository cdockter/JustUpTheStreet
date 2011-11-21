# Create your views here.
from fe.models import *
from fe.forms import *
from django.shortcuts import render_to_response
from django.template import *
from django.http import *
from django.core.context_processors import csrf


def index(request):
    #return HttpResponse("Hello, world. You're at the prize index.")
    prize_list = Prize.objects.all()
    return render_to_response('fe/prize/view.html', {'prize_list': prize_list})
    
def prize(request, prize_id):
    prize = Prize.objects.get(id=prize_id)
    
def create_prize(request):
    if 'POST' == request.method:
        form = PrizeForm(request.POST)
        
        if form.is_valid():
            state         = PrizeState()
            state.name    = 'draft'
            state.expires = '2012-12-12'
            state.save()
            
            prize   = Prize()
            prize.creator       = Account.objects.get(id=1)
            prize.name          = form.cleaned_data['name']
            prize.description   = form.cleaned_data['description']
            prize.state = state
            prize.save()
            contrib = Contribution()
            contrib.contributor = prize.creator
            contrib.amount = form.cleaned_data['contributions']
            contrib.expires = form.cleaned_data['expires']
            contrib.save()
            prize.contributions.add(contrib)
            prize.save()
            return HttpResponse("Prize %s Created!" %prize.name)
        else:
            return HttpResponse("Form not valid!")
    else:
        form = PrizeForm()
        login_form   = LoginForm()
        return render_to_response('fe/prize/create.html', {'form': form, 'login_form': login_form}, RequestContext(request))
    

def detail(request, prize_id):
    #prize_list = Prize.objects.all()
    #return render_to_response('fe/prizes/index.html', {'prize_list': prize_list})
    return HttpResponse("Hello, world. You're at the prize details: %s" % prize_id)
    