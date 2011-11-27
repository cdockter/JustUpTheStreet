# Create your views here.
from fe.models import *
from fe.forms import *
from django.shortcuts import render_to_response
from django.template import *
from django.http import *
from django.core.context_processors import csrf
from django.contrib.auth import *

def Login(request, username):
    response    = HttpResponse("You must provide a username and password")
    login_form  = LoginForm()
    login_msg   = ""
    if 'POST' == request.method:
        form = LoginForm(request.POST)
        
        if form.is_valid():
            password = form.cleaned_data['password']
            user = authenticate(username=username, password=password)
            if user is not None:
                if user.is_active:
                    login(request, user)
                    response    = render_to_response("common/login.html", {'login_form': login_form, 'login_msg': login_msg }, RequestContext(request))
                    #return HttpResponse("Welcome %s!" % user.get_full_name() )
                else:
                    response = HttpResponse("Account Disabled")
                    response.status_code = 409
            else:
                response = HttpResponse("Bad Username or Password")
                response.status_code = 401
    
    return response
    
def Logout(request, username):
    logout(request)
    login_form  = LoginForm()
    return render_to_response("common/login.html", {'login_form': login_form }, RequestContext(request))