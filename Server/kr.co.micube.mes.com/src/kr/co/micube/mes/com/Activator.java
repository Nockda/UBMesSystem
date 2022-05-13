package kr.co.micube.mes.com;

import org.osgi.framework.BundleActivator;
import org.osgi.framework.BundleContext;

import kr.co.micube.common.util.PluginEnvironment;

public class Activator implements BundleActivator {

	private static BundleContext context;

	static BundleContext getContext() {
		return context;
	}

	/*
	 * (non-Javadoc)
	 * @see org.osgi.framework.BundleActivator#start(org.osgi.framework.BundleContext)
	 */
	public void start(BundleContext bundleContext) throws Exception {
		Activator.context = bundleContext;
		PluginEnvironment.registerScanComponent(bundleContext);
	}

	/*
	 * (non-Javadoc)
	 * @see org.osgi.framework.BundleActivator#stop(org.osgi.framework.BundleContext)
	 */
	public void stop(BundleContext bundleContext) throws Exception {
		Activator.context = null;
		PluginEnvironment.unregisterScanComponent(bundleContext);
	}
}