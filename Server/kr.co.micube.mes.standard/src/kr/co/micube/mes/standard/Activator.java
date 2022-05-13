package kr.co.micube.mes.standard;

import org.osgi.framework.BundleActivator;
import org.osgi.framework.BundleContext;

import kr.co.micube.common.util.PluginEnvironment;

public class Activator implements BundleActivator {

	private static BundleContext context;

	static BundleContext getContext() {
		return context;
	}

	public void start(BundleContext bundleContext) throws Exception {
		Activator.context = bundleContext;
		PluginEnvironment.registerScanComponent(bundleContext);
	}

	public void stop(BundleContext bundleContext) throws Exception {
		Activator.context = null;
		PluginEnvironment.registerScanComponent(bundleContext);
	}

}
