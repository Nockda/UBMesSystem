package kr.co.micube.mes.equipment.main;

import org.osgi.framework.BundleActivator;
import org.osgi.framework.BundleContext;

import kr.co.micube.common.util.PluginEnvironment;

public class Activator implements BundleActivator {

	private static BundleContext context;
	
	static BundleContext getContext() {
		return context;
	}
	
	@Override
	public void start(BundleContext bundleContext) throws Exception {
		Activator.context = bundleContext;
		PluginEnvironment.registerScanComponent(bundleContext);

	}

	@Override
	public void stop(BundleContext bundleContext) throws Exception {
		Activator.context = null;
		PluginEnvironment.unregisterScanComponent(bundleContext);

	}

}
