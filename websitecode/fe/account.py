# Create your views here.
from fe.models import *
from fe.forms import *
from django.shortcuts import render_to_response
from django.template import *
from django.http import *
from django.core.context_processors import csrf
from django.contrib.auth import *

def Login(request, username):
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
                    #return HttpResponse("Welcome %s!" % user.get_full_name() )
                else:
                    res = HttpResponse("Account Disabled")
                    res.status_code = 409
                    return res
            else:
                res = HttpResponse("Bad Username or Password")
                res.status_code = 401
                return res
        else:
            
            login_form.username.initial = username
            login_msg   = "You must provide a username and password"
    
    return render_to_response("common/login.html", {'login_form': login_form, 'login_msg': login_msg }, RequestContext(request))
    
def Logout(request, username):
    logout(request)
    login_form  = LoginForm()
    return render_to_response("common/login.html", {'login_form': login_form }, RequestContext(request))