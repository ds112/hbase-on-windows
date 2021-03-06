/*! JsRender v1.0pre: http://github.com/BorisMoore/jsrender */
(function (n, t, i) {
    "use strict";
    function tt(n, t) {
        t && t.onError && t.onError(n) === !1 || (this.name = "JsRender Error", this.message = n || "JsRender error")
    }
    function e(n, t) {
        var i;
        n = n || {};
        for (i in t)
            n[i] = t[i];
        return n
    }
    function lt(n, t, i) {
        return (!d.rTag || arguments.length) && (p = n ? n.charAt(0) : p, w = n ? n.charAt(1) : w, s = t ? t.charAt(0) : s, y = t ? t.charAt(1) : y, b = i || b, n = "\\" + p + "(\\" + b + ")?\\" + w, t = "\\" + s + "\\" + y, v = "(?:(?:(\\w+(?=[\\/\\s\\" + s + "]))|(?:(\\w+)?(:)|(>)|!--((?:[^-]|-(?!-))*)--|(\\*)))\\s*((?:[^\\" + s + "]|\\" + s + "(?!\\" + y + "))*?)", d.rTag = v + ")", v = new RegExp(n + v + "(\\/)?|(?:\\/(\\w+)))" + t, "g"), ft = new RegExp("<.*>|([^\\\\]|^)[{}]|" + n + ".*" + t)),
		[p, w, s, y, b]
    }
    function hi(n, t) {
        t || (t = n, n = i);
        var e,
		f,
		o,
		u,
		r = this,
		s = !t || t === "root";
        if (n) {
            if (u = r.type === t ? r : i, !u)
                if (e = r.views, r._.useKey) {
                    for (f in e)
                        if (u = e[f].get(n, t))
                            break
                } else
                    for (f = 0, o = e.length; !u && f < o; f++)
                        u = e[f].get(n, t)
        } else if (s)
            while (r.parent.parent)
                u = r = r.parent;
        else
            while (r && !u)
                u = r.type === t ? r : i, r = r.parent;
        return u
    }
    function yt() {
        var n = this.get("item");
        return n ? n.index : i
    }
    function ci(n) {
        var r,
		u = this,
		t = (u.ctx || {})[n];
        return t = t === i ? u.getRsc("helpers", n) : t,
		t && typeof t == "function" && (r = function () {
		    return t.apply(u, arguments)
		}, e(r, t)),
		r || t
    }
    function fi(n, t, i) {
        var s,
		u,
		o,
		f = +i === i && i,
		e = t.linkCtx;
        return f && (i = (f = t.tmpl.bnds[f - 1])(t.data, t, r)),
		o = i.args[0],
		(n || f) && (u = e && e.tag || {
		    _: {
		        inline: !e
		    },
		    tagName: n + ":",
		    flow: !0,
		    _is: "tag"
		}, u._.bnd = f, e && (e.tag = u, u.linkCtx = e, i.ctx = h(i.ctx, e.view.ctx)), u.tagCtx = i, i.view = t, u.ctx = i.ctx || {}, delete i.ctx, t._.tag = u, n = n !== "true" && n, n && ((s = t.getRsc("converters", n)) || a("Unknown converter: {{" + n + ":")) && (u.depends = s.depends, o = s.apply(u, i.args)), o = f && t._.onRender ? t._.onRender(o, t, f) : o),
		o
    }
    function ei(n, t) {
        for (var e = this, u = r[n], f = u && u[t]; f === i && e;)
            u = e.tmpl[n], f = u && u[t], e = e.parent;
        return f
    }
    function oi(n, t, u, o) {
        var et,
		s,
		ot,
		it,
		ct,
		nt,
		l,
		tt,
		rt,
		c,
		k,
		b,
		st,
		p,
		w = "",
		d = +o === o && o,
		v = t.linkCtx || 0,
		y = t.ctx,
		ft = u || t.tmpl,
		ht = t._;
        for (n._is === "tag" && (s = n, n = s.tagName), d && (o = (st = ft.bnds[d - 1])(t.data, t, r)), tt = o.length, s = s || v.tag, l = 0; l < tt; l++)
            c = o[l], b = c.tmpl, b = c.content = b && ft.tmpls[b - 1], u = c.props.tmpl, l || u && s || (p = t.getRsc("tags", n) || a("Unknown tag: {{" + n + "}}")), u = u || !l && p.template || b, u = "" + u === u ? t.getRsc("templates", u) || f(u) : u, e(c, {
                tmpl: u,
                render: g,
                index: l,
                view: t,
                ctx: h(c.ctx, y)
            }), s || (p.init ? (s = new p.init(c, v, y), s.attr = s.attr || p.attr || i) : s = {
                render: p.render
            }, s._ = {
                inline: !v
            }, v && (v.attr = s.attr = v.attr || s.attr, v.tag = s, s.linkCtx = v), (s._.bnd = st || v) && (s._.arrVws = {}), s.tagName = n, s.parent = nt = y && y.tag, s._is = "tag"), ht.tag = s, c.tag = s, s.tagCtxs = o, s.rendering = {},
		s.flow || (k = c.ctx = c.ctx || {}, ot = k.parentTags = y && h(k.parentTags, y.parentTags) || {}, nt && (ot[nt.tagName] = nt), k.tag = s);
        for (l = 0; l < tt; l++)
            c = s.tagCtx = o[l], s.ctx = c.ctx, (et = s.render) && (rt = et.apply(s, c.args)), w += rt !== i ? rt : c.tmpl ? c.render() : "";
        return delete s.rendering,
		s.tagCtx = s.tagCtxs[0],
		s.ctx = s.tagCtx.ctx,
		s._.inline && (it = s.attr) && it !== "html" && (w = it === "text" ? ut.html(w) : ""),
		w = d && t._.onRender ? t._.onRender(w, t, d) : w
    }
    function k(n, t, r, u, f, e, o, s) {
        var v,
		a,
		c,
		y = t === "array",
		l = {
		    key: 0,
		    useKey: y ? 0 : 1,
		    id: "" + ai++,
		    onRender: s,
		    bnds: {}
		},
		h = {
		    data: u,
		    tmpl: f,
		    content: o,
		    views: y ? [] : {},
		    parent: r,
		    ctx: n,
		    type: t,
		    get: hi,
		    getIndex: yt,
		    getRsc: ei,
		    hlp: ci,
		    _: l,
		    _is: "view"
		};
        return r && (v = r.views, a = r._, a.useKey ? (v[l.key = "_" + a.useKey++] = h, c = a.tag, l.bnd = y && (!c || !!c._.bnd && c)) : v.splice(l.key = h.index = e !== i ? e : v.length, 0, h), h.ctx = n || r.ctx),
		h
    }
    function pi(n) {
        var r,
		i,
		t,
		u,
		f;
        for (r in c)
            if (u = c[r], (f = u.compile) && (i = n[r + "s"]))
                for (t in i)
                    i[t] = f(t, i[t], n, r, u)
    }
    function vi(n, t, i) {
        var u,
		r;
        return typeof t == "function" ? t = {
            depends: t.depends,
            render: t
        }
		 : ((r = t.template) && (t.template = "" + r === r ? f[r] || f(r) : r), t.init !== !1 && (u = t.init = t.init || function () { }, u.prototype = t, (u.prototype = t).constructor = u)),
		i && (t._parentTmpl = i),
		t
    }
    function st(r, u, e, o, s, c) {
        function v(i) {
            if ("" + i === i || i.nodeType > 0) {
                try {
                    a = i.nodeType > 0 ? i : !ft.test(i) && t && t(n.document).find(i)[0]
                } catch (u) { }

                return a && (i = a.getAttribute(vt), r = r || i, i = f[i], i || (r = r || "_" + li++, a.setAttribute(vt, r), i = f[r] = st(r, a.innerHTML, e, o, s, c))),
				i
            }
        }
        var l,
		a;
        return u = u || "",
		l = v(u),
		c = c || (u.markup ? u : {}),
		c.tmplName = r,
		e && (c._parentTmpl = e),
		!l && u.markup && (l = v(u.markup)) && l.fn && (l.debug !== u.debug || l.allowCode !== u.allowCode) && (l = l.markup),
		l !== i ? (r && !e && (nt[r] = function () {
		    return u.render.apply(u, arguments)
		}), l.fn || u.fn ? l.fn && (u = r && r !== l.tmplName ? h(c, l) : l) : (u = ht(l, c), ot(l, u)), pi(c), u) : void 0
    }
    function ht(n, t) {
        var r,
		f = l.wrapMap || {},
		i = e({
		    markup: n,
		    tmpls: [],
		    links: {},
		    tags: {},
		    bnds: [],
		    _is: "template",
		    render: g
		}, t);
        return t.htmlTag || (r = bt.exec(n), i.htmlTag = r ? r[1].toLowerCase() : ""),
		r = f[i.htmlTag],
		r && r !== f.div && (i.markup = u.trim(i.markup), i._elCnt = !0),
		i
    }
    function ui(n, t) {
        function f(e, o, s) {
            var l,
			h,
			a,
			c;
            if (e && "" + e !== e && !e.nodeType && !e.markup) {
                for (a in e)
                    f(a, e[a], o);
                return r
            }
            return c = s ? s[u] = s[u] || {}

			 : f,
			o === i && (o = e, e = i),
			h = t.compile,
			(l = d.onBeforeStoreItem) && (h = l(c, e, o, h) || h),
			e ? "" + e === e && (o === null ? delete c[e] : c[e] = h ? o = h(e, o, s, n, t) : o) : o = h(i, o),
			o && (o._is = n),
			(l = d.onStoreItem) && l(c, e, o, h),
			o
        }
        var u = n + "s";
        r[u] = f,
		c[n] = t
    }
    function g(n, t, e, o, s, c) {
        var b,
		ft,
		nt,
		y,
		tt,
		it,
		rt,
		w,
		p,
		et,
		d,
		ut,
		v,
		l = this,
		ot = !l.attr || l.attr === "html",
		g = "";
        if (o === !0 && (rt = !0, o = 0), l.tag ? (w = l, l = l.tag, et = l._, ut = l.tagName, v = w.tmpl, t = h(t, l.ctx), p = w.content, w.props.link === !1 && (t = t || {}, t.link = !1), e = e || w.view, n = n === i ? e : n) : v = l.jquery && (l[0] || a('Unknown template: "' + l.selector + '"')) || l, v && (!e && n && n._is === "view" && (e = n), e && (p = p || e.content, c = c || e._.onRender, n === e && (n = e.data, s = !0), t = h(t, e.ctx)), e && e.data !== i || ((t = t || {}).root = n), v.fn || (v = f[v] || f(v)), v)) {
            if (c = (t && t.link) !== !1 && ot && c, d = c, c === !0 && (d = i, c = e._.onRender), u.isArray(n) && !s)
                for (y = rt ? e : o !== i && e || k(t, "array", e, n, v, o, p, c), b = 0, ft = n.length; b < ft; b++)
                    nt = n[b], tt = k(t, "item", y, nt, v, (o || 0) + b, p, c), it = v.fn(nt, tt, r), g += y._.onRender ? y._.onRender(it, tt) : it;
            else
                y = rt ? e : k(t, ut || "data", e, n, v, o, p, c), et && !l.flow && (y.tag = l), g += v.fn(n, y, r);
            return d ? d(g, y) : g
        }
        return ""
    }
    function a(n) {
        if (l.debugMode)
            throw new r.sub.Error(n);
    }
    function o(n) {
        a("Syntax error\n" + n)
    }
    function ot(n, t, i, r) {
        function a(t) {
            t -= f,
			t && h.push(n.substr(f, t).replace(rt, "\\n"))
        }
        function c(t) {
            t && o('Unmatched or missing tag: "{{/' + t + '}}" in template:\n' + n)
        }
        function y(t, e, v, y, w, b, k, d, g, nt, tt, it) {
            b && (w = ":", y = "html"),
			nt = nt || i;
            var lt,
			st,
			ht = e && [],
			ft = "",
			ut = "",
			ot = "",
			et = !nt && !w && !k;
            v = v || w,
			a(it),
			f = it + t.length,
			d ? p && h.push(["*", "\n" + g.replace(ri, "$1") + "\n"]) : v ? (v === "else" && (pt.test(g) && o('for "{{else if expr}}" use "{{else expr}}"'), ht = u[6], u[7] = n.substring(u[7], it), u = s.pop(), h = u[3], et = !0), g && (g = g.replace(rt, " "), ft = ct(g, ht).replace(wt, function (n, t, i) {
			    return t ? ot += i + "," : ut += i + ",",
                ""
			})), ut = ut.slice(0, -1), ft = ft.slice(0, -1), lt = ut && ut.indexOf("noerror:true") + 1 && ut || "", l = [v, y || !!r || "", ft, et && [], 'params:"' + g + '",props:{' + ut + "}" + (ot ? ",ctx:{" + ot.slice(0, -1) + "}" : ""), lt, ht || 0], h.push(l), et && (s.push(u), u = l, u[7] = f)) : tt && (st = u[0], c(tt !== st && st !== "else" && tt), u[7] = n.substring(u[7], it), u = s.pop()),
			c(!u && tt),
			h = u[3]
        }
        var l,
		p = t && t.allowCode,
		e = [],
		f = 0,
		s = [],
		h = e,
		u = [, , , e];
        return n = n.replace(ii, "\\$1"),
		c(s[0] && s[0][3].pop()[0]),
		n.replace(v, y),
		a(n.length),
		(f = e[e.length - 1]) && c("" + f !== f && +f[7] === f[7] && f[0]),
		et(e, t || n, i)
    }
    function et(n, i, r) {
        var c,
		e,
		f,
		y,
		v,
		p,
		vt,
		yt,
		at,
		it,
		d,
		s,
		kt,
		gt,
		ot,
		a,
		ft,
		b,
		bt,
		tt,
		pt,
		ni,
		g,
		lt,
		ct,
		st,
		nt,
		w,
		h = 0,
		u = "",
		k = "",
		ut = {},
		wt = n.length;
        for ("" + i === i ? (a = r ? 'data-link="' + i.replace(rt, " ").slice(1, -1) + '"' : i, i = 0) : (a = i.tmplName || "unnamed", (bt = i.allowCode) && (ut.allowCode = !0), i.debug && (ut.debug = !0), d = i.bnds, ot = i.tmpls), c = 0; c < wt; c++)
            if (e = n[c], "" + e === e)
                u += '\nret+="' + e + '";';
            else if (f = e[0], f === "*")
                u += "" + e[1];
            else {
                if (y = e[1], v = e[2], tt = e[3], p = e[4], k = e[5], pt = e[7], (ct = f === "else") || (h = 0, d && (s = e[6]) && (h = d.push(s))), (st = f === ":") ? (y && (f = y === "html" ? ">" : y + f), k && (nt = "prm" + c, k = "try{var " + nt + "=[" + v + "][0];}catch(e){" + nt + '="";}\n', v = nt)) : (tt && (ft = ht(pt, ut), ft.tmplName = a + "/" + f, et(tt, ft), ot.push(ft)), ct || (b = f, lt = u, u = "", kt = c), g = n[c + 1], g = g && g[0] === "else"), p += ",args:[" + v + "]}", st && s || y && f !== ">") {
                    if (w = new Function("data,view,j,u", " // " + a + " " + h + " " + f + "\n" + k + "return {" + p + ";"), w.paths = s, w._ctxs = f, r)
                        return w;
                    it = !0
                }
                if (u += st ? "\n" + (s ? "" : k) + (r ? "return " : "ret+=") + (it ? (it = !0, 'c("' + y + '",view,' + (s ? (d[h - 1] = w, h) : "{" + p) + ");") : f === ">" ? (yt = !0, "h(" + v + ");") : (at = !0, "(v=" + v + ")!=" + (r ? "=" : "") + 'u?v:"";')) : (vt = !0, "{tmpl:" + (tt ? ot.length : "0") + "," + p + ","), b && !g) {
                    if (u = "[" + u.slice(0, -1) + "]", (r || s) && (u = new Function("data,view,j,u", " // " + a + " " + h + " " + b + "\nreturn " + u + ";"), s && ((d[h - 1] = u).paths = s), u._ctxs = f, r))
                        return u;
                    u = lt + '\nret+=t("' + b + '",view,this,' + (h || u) + ");",
					s = 0,
					b = 0
                }
            }
        u = "// " + a + "\nvar j=j||" + (t ? "jQuery." : "js") + "views" + (at ? ",v" : "") + (vt ? ",t=j._tag" : "") + (it ? ",c=j._cnvt" : "") + (yt ? ",h=j.converters.html" : "") + (r ? ";\n" : ',ret="";\n') + (l.tryCatch ? "try{\n" : "") + (ut.debug ? "debugger;" : "") + u + (r ? "\n" : "\nreturn ret;\n") + (l.tryCatch ? "\n}catch(e){return j._err(e);}" : "");
        try {
            u = new Function("data,view,j,u", u)
        } catch (dt) {
            o("Compiled template code:\n\n" + u, dt)
        }
        return i && (i.fn = u),
		u
    }
    function ct(n, t) {
        function c(c, l, a, v, y, p, w, b, k, d, g, nt, tt, it, rt, ut, ft, et, ot) {
            function ht(n, i, r, u, f, o, s) {
                if (i && (t && !e && t.push(v), i !== ".")) {
                    var h = (r ? 'view.hlp("' + r + '")' : u ? "view" : "data") + (s ? (f ? "." + f : r ? "" : u ? "" : "." + i) + (o || "") : (s = r ? "" : u ? f || "" : i, ""));
                    return h = h + (s ? "." + s : ""),
					h.slice(0, 9) === "view.data" ? h.slice(5) : h
                }
                return n
            }
            if (y = y || "", a = a || l || g, v = v || b, t && rt && t.push({
                _jsvOb: ot.slice(h[i - 1] + 1, et + 1)
            }), k = k || ut || "", p)
                o(n);
            else
                return f ? (f = !nt, f ? c : '"') : u ? (u = !tt, u ? c : '"') : (a ? (i++, h[i] = et, a) : "") + (ft ? i ? "" : s ? (s = e = !1, "\b") : "," : w ? (i && o(n), s = v, e = v.charAt(0) === "~", "\b" + v + ":") : v ? v.split("^").join(".").replace(kt, ht) + (k ? (r[++i] = !0, k) : y) : y ? y : it ? (r[i--] = !1, it) + (k ? (r[++i] = !0, k) : "") : d ? (r[i] || o(n), ",") : l ? "" : (f = nt, u = tt, '"'))
        }
        var s,
		e,
		r = {},
		h = {
		    0: -1
		},
		i = 0,
		u = !1,
		f = !1;
        return (n + " ").replace(ti, c)
    }
    function h(n, t) {
        return n && n !== t ? t ? e(e({}, t), n) : n : t && e({}, t)
    }
    function at(n) {
        return yi[n]
    }
    if ((!t || !t.views) && !n.jsviews) {
        var ni = "v1.0pre",
		u,
		it,
		v,
		ft,
		p = "{",
		w = "{",
		s = "}",
		y = "}",
		b = "^",
		kt = /^(?:null|true|false|\d[\d.]*|([\w$]+|\.|~([\w$]+)|#(view|([\w$]+))?)([\w$.^]*?)(?:[.[^]([\w$]+)\]?)?)$/g,
		ti = /(\()(?=\s*\()|(?:([([])\s*)?(?:([#~]?[\w$.^]+)?\s*((\+\+|--)|\+|-|&&|\|\||===|!==|==|!=|<=|>=|[<>%*!:?\/]|(=))\s*|([#~]?[\w$.^]+)([([])?)|(,\s*)|(\(?)\\?(?:(')|("))|(?:\s*((\))(?=\s*\.|\s*\^)|\)|\])([([]?))|(\s+)/g,
		rt = /\s*\n/g,
		ri = /\\(['"])/g,
		ii = /([\\'"])/g,
		wt = /\x08(~)?([^\x08]+)\x08/g,
		pt = /^if\s/,
		bt = /<(\w+)[>\s]/,
		ki = /<(\w+)[^>\/]*>[^>]*$/,
		dt = /[<"'&]/g,
		si = /[><"'&]/g,
		li = 0,
		ai = 0,
		yi = {
		    "&": "&amp;",
		    "<": "&lt;",
		    ">": "&gt;",
		    "\x00": "&#0;",
		    "'": "&#39;",
		    '"': "&#34;"
		},
		vt = "data-jsv-tmpl",
		wi = [].slice,
		nt = {},
		c = {
		    template: {
		        compile: st
		    },
		    tag: {
		        compile: vi
		    },
		    helper: {},
		    converter: {}
		},
		r = {
		    jsviews: ni,
		    render: nt,
		    View: k,
		    settings: {
		        delimiters: lt,
		        debugMode: !0,
		        tryCatch: !0
		    },
		    sub: {
		        Error: tt,
		        tmplFn: ot,
		        parse: ct,
		        extend: e,
		        error: a,
		        syntaxError: o
		    },
		    _cnvt: fi,
		    _tag: oi,
		    _err: function (n) {
		        return l.debugMode ? "Error: " + (n.message || n) + ". " : ""
		    }
		};
        (tt.prototype = new Error).constructor = tt,
		yt.depends = function () {
		    return [this.get("item"), "index"]
		};
        for (it in c)
            ui(it, c[it]);
        var f = r.templates,
		ut = r.converters,
		bi = r.helpers,
		gt = r.tags,
		d = r.sub,
		l = r.settings;
        t ? (u = t, u.fn.render = g) : (u = n.jsviews = {}, u.isArray = Array && Array.isArray || function (n) {
            return Object.prototype.toString.call(n) === "[object Array]"
        }),
		u.render = nt,
		u.views = r,
		u.templates = f = r.templates,
		gt({
		    "else": function () { },
		    "if": {
		        render: function (n) {
		            var t = this;
		            return t.rendering.done || !n && (arguments.length || !t.tagCtx.index) ? "" : (t.rendering.done = !0, t.selected = t.tagCtx.index, t.tagCtx.render())
		        },
		        onUpdate: function (n, t, i) {
		            for (var r, f, u = 0; (r = this.tagCtxs[u]) && r.args.length; u++)
		                if (r = r.args[0], f = !r != !i[u].args[0], !!r || f)
		                    return f;
		            return !1
		        },
		        flow: !0
		    },
		    "for": {
		        render: function (n) {
		            var h,
					s,
					t = this,
					o = t.tagCtx,
					f = !arguments.length,
					r = "",
					e = f || 0;
		            return t.rendering.done || (f ? r = i : n !== i && (r += o.render(n), e += u.isArray(n) ? n.length : 1), (t.rendering.done = e) && (t.selected = o.index)),
					r
		        },
		        onUpdate: function () { },
		        onArrayChange: function (n, t) {
		            var i,
					u = this,
					r = t.change;
		            if (this.tagCtxs[1] && (r === "insert" && n.target.length === t.items.length || r === "remove" && !n.target.length || r === "refresh" && !t.oldItems.length != !n.target.length))
		                this.refresh();
		            else
		                for (i in u._.arrVws)
		                    i = u._.arrVws[i], i.data === n.target && i._.onArrayChange.apply(i, arguments);
		            n.done = !0
		        },
		        flow: !0
		    },
		    include: {
		        flow: !0
		    },
		    "*": {
		        render: function (n) {
		            return n
		        },
		        flow: !0
		    }
		}),
		ut({
		    html: function (n) {
		        return n != i ? String(n).replace(si, at) : ""
		    },
		    attr: function (n) {
		        return n != i ? String(n).replace(dt, at) : n === null ? null : ""
		    },
		    url: function (n) {
		        return n != i ? encodeURI(String(n)) : n === null ? null : ""
		    }
		}),
		lt()
    }
})(this, this.jQuery)