# Create your views here.

from django.http import HttpResponse

def index(request):
    return HttpResponse("Hello, world. You're at the prize index.")

def detail(request, prize_id):
    return HttpResponse("Hello, world. You're at the prize details.") 