# Create your views here.
from fe.models import *
from django.shortcuts import render_to_response
from django.http import *

def index(request):
    #return HttpResponse("Hello, world. You're at the prize index.")
    prize_list = Prize.objects.all()
    return render_to_response('fe/prize/index.html', {'prize_list': prize_list})

def detail(request, prize_id):
    #prize_list = Prize.objects.all()
    #return render_to_response('fe/prizes/index.html', {'prize_list': prize_list})
    return HttpResponse("Hello, world. You're at the prize details: %s" % prize_id)
    